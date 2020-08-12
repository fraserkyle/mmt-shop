using Dapper;
using Mmt.Shop.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Mmt.Shop.DataAccess.Dapper
{
    public abstract class DapperDataAccessBase
    {
        protected async Task<IEnumerable<T>> ProcedureAsync<T>(string name)
        {
            using var connection = new SqlConnection(Environment.GetEnvironmentVariable(EnvironmentVariables.CATALOGUE_CONN_STRING));

            try
            {
                connection.Open();
                connection.Execute($"USE {Environment.GetEnvironmentVariable(EnvironmentVariables.DB_NAME)}");
                return await connection.QueryAsync<T>($"EXEC {name}");
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
    }
}
