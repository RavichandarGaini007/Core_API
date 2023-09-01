using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Common.DataAccessLayer
{
    public class DAL : IDAL
    {
        private readonly IDBConnection _connection;

        public DAL(IDBConnection connection)
        {
            _connection = connection;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connection.GetConnection());
        }

        public async Task<GridReader> RunMultipleQueryAsync(string query, CommandType commandType,  DynamicParameters parameters = null)
        {
            using (var conn = GetConnection())
            {
                var queryResult = await conn.QueryMultipleAsync(query, parameters, commandType: commandType);
                return queryResult;
            }
        }
        public async Task<IEnumerable<T>> GetIEnumerableData<T>(string query, CommandType commandType,  DynamicParameters parameters = null, int timeOut = 60) where T : class
        {
            using (var conn = GetConnection())
            {
                var result = await conn.QueryAsync<T>(query, parameters, commandType: commandType, commandTimeout: timeOut);
                return result;
            }
        }

        public async Task<T> GetData<T>(string query, CommandType commandType = CommandType.StoredProcedure,  DynamicParameters parameters = null) where T : class
        {
            using (var conn = GetConnection())
            {
                var result = await conn.QueryFirstOrDefaultAsync<T>(query, parameters, commandType: commandType);
                return result;
            }
        }


        public async Task<int> GetScalarData(string query, CommandType commandType = CommandType.StoredProcedure,  DynamicParameters parameters = null)
        {
            using (var conn = GetConnection())
            {
                var result = await conn.ExecuteScalarAsync<int>(query, parameters, commandType: commandType);
                return result;
            }
        }


        public async Task<string> GetScalarStringData(string query, CommandType commandType = CommandType.StoredProcedure,  DynamicParameters parameters = null)
        {
            using (var conn = GetConnection())
            {
                var result = await conn.ExecuteScalarAsync<string>(query, parameters, commandType: commandType);
                return result;
            }
        }

        public async Task<int> ExecuteQuery(string query, CommandType commandType = CommandType.StoredProcedure,  DynamicParameters parameters = null)
        {
            using (var conn = GetConnection())
            {
                var result = await conn.ExecuteAsync(query, parameters, commandType: commandType);
                return result;
            }
        }
    }
}
