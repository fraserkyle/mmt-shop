using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Transactions;

namespace Mmt.Shop.DataAccess.ScriptRunner
{
    public class ScriptRunnerClient : IScriptRunnerClient
    {
        private ScriptRunnerSettings _settings;
        private string _dbName;

        public ScriptRunnerClient(ScriptRunnerSettings settings)
        {
            _settings = settings;
            _dbName = _settings.BasePath.Replace("/", @"\").Split(@"\", System.StringSplitOptions.None).Last();
        }

        public void Run()
        {
            var changeLog = JsonConvert.DeserializeObject<ChangeLog>(File.ReadAllText(Path.Combine(_settings.BasePath, "ChangeLog.json")));

            using var connection = new SqlConnection(_settings.ConnectionString);

            EnsureDatabaseExists(connection);

            EnsureChangeLogTablesExist(connection);

            var existing = GetExisting(connection);

            foreach (var change in changeLog.Changes.Where(x => !existing.Contains(x.Version)).OrderBy(x => x.ReleaseDate))
            {
                using var scope = new TransactionScope();

                foreach (var script in change.Scripts)
                {
                    ExecuteSql(connection, File.ReadAllText($"{Path.Combine(_settings.BasePath, script)}.sql"), _dbName);
                }

                ExecuteSql(connection, Resources.ResourceManager.GetString("InsertChangeCommand").Replace("{ChangeVersion}", change.Version), _dbName);

                scope.Complete();
            }
        }

        private IEnumerable<string> GetExisting(SqlConnection connection)
        {
            var result = new List<string>();

            try
            {
                connection.Open();
                using var command = new SqlCommand($"USE {_dbName}; {Resources.ResourceManager.GetString("GetExistingCommand")}", connection);

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader.GetString(0));
                }

                connection.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        private void EnsureDatabaseExists(SqlConnection connection)
        {
            ExecuteSql(connection, Resources.ResourceManager.GetString("CreateDatabaseCommand").Replace("{DBNAME}", _dbName));
        }

        private void ExecuteSql(SqlConnection connection, string sql, string dbName = null)
        {
            try
            {
                connection.Open();

                if (dbName != null)
                {
                    using var useCommand = new SqlCommand($"USE {dbName}", connection);
                    useCommand.ExecuteNonQuery();
                }

                using var command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        private void EnsureChangeLogTablesExist(SqlConnection connection)
        {
            ExecuteSql(connection, Resources.ResourceManager.GetString("CreateChangeLog"), _dbName);
        }
    }
}
