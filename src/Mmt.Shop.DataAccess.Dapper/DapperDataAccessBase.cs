using Dapper;
using Mmt.Shop.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Mmt.Shop.DataAccess.Dapper
{
    public abstract class DapperDataAccessBase
    {
        private readonly IDbConnection _connection;

        protected DapperDataAccessBase(IDbConnection connection)
        {
            _connection = connection;
        } 

        protected async Task<IEnumerable<T>> ProcedureAsync<T>(string name)
        {
            try
            {
                _connection.Open();
                _connection.Execute($"USE {Environment.GetEnvironmentVariable(EnvironmentVariables.DB_NAME)}");
                return await _connection.QueryAsync<T>($"EXEC {name}");
            }
            catch
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
