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

        private SqlConnection GetConnection(string conn)
        {
            return new SqlConnection(_connection.GetConnection(conn));
        }

        public async Task<GridReader> RunMultipleQueryAsync(string query, CommandType commandType,  DynamicParameters parameters = null,string conn_str=null)
        {
            using (var conn = GetConnection(conn_str))
            {
                var queryResult = await conn.QueryMultipleAsync(query, parameters, commandType: commandType, commandTimeout:60);
                return queryResult;
            }
        }
        public async Task<IEnumerable<T>> GetIEnumerableData<T>(string query, CommandType commandType,  DynamicParameters parameters = null,string conn_str=null, int timeOut = 300) where T : class
        {
            using (var conn = GetConnection(conn_str))
            {
                var result = await conn.QueryAsync<T>(query, parameters, commandType: commandType, commandTimeout: timeOut);
                return result;
            }
        }
        public async Task<T> GetData<T>(string query, CommandType commandType = CommandType.StoredProcedure,  DynamicParameters parameters = null, string conn_str = null) where T : class
        {
            using (var conn = GetConnection(conn_str))
            {
                var result = await conn.QueryFirstOrDefaultAsync<T>(query, parameters, commandType: commandType);
                return result;
            }
        }


        public async Task<int> GetScalarData(string query, CommandType commandType = CommandType.StoredProcedure,  DynamicParameters parameters = null, string conn_str = null)
        {
            using (var conn = GetConnection(conn_str))
            {
                var result = await conn.ExecuteScalarAsync<int>(query, parameters, commandType: commandType);
                return result;
            }
        }


        public async Task<string> GetScalarStringData(string query, CommandType commandType = CommandType.StoredProcedure,  DynamicParameters parameters = null, string conn_str = null)
        {
            using (var conn = GetConnection(conn_str))
            {
                var result = await conn.ExecuteScalarAsync<string>(query, parameters, commandType: commandType);
                return result;
            }
        }

        public async Task<int> ExecuteQuery(string query, CommandType commandType = CommandType.StoredProcedure,  DynamicParameters parameters = null, string conn_str = null)
        {
            using (var conn = GetConnection(conn_str))
            {
                var result = await conn.ExecuteAsync(query, parameters, commandType: commandType);
                return result;
            }
        }
        public async Task<DataTable> GetDataTable<T>(string query, CommandType commandType, DynamicParameters parameters = null, string conn_str = null) where T : class
        {
            using (var conn = GetConnection(conn_str))
            {
                var result = await conn.QueryAsync(query, parameters, commandType: commandType);
                return ConvertToDataTable(result);
            }
        }

        public async Task<DataSet> GetDataSet<T>(string query, CommandType commandType, DynamicParameters parameters = null, string conn_str = null) where T : class
        {
            using (var conn = GetConnection(conn_str))
            {
                var result = await conn.QueryMultipleAsync(query, parameters, commandType: commandType);
                return ConvertToDataSet(result);
            }
        }
        private DataTable ConvertToDataTable(IEnumerable<dynamic> data)
        {
            DataTable dataTable = new DataTable();

            if (data != null)
            {
                foreach (var item in data)
                {
                    if (dataTable.Columns.Count == 0)
                    {
                        foreach (var property in (IDictionary<string, object>)item)
                        {
                            dataTable.Columns.Add(property.Key, property.Value?.GetType() ?? typeof(object));
                        }
                    }

                    DataRow row = dataTable.NewRow();
                    foreach (var property in (IDictionary<string, object>)item)
                    {
                        row[property.Key] = property.Value ?? DBNull.Value;
                    }
                    dataTable.Rows.Add(row);
                }
            }


            return dataTable;
        }
        private DataSet ConvertToDataSet(SqlMapper.GridReader multi)
        {
            DataSet dataSet = new DataSet();

            while (!multi.IsConsumed)
            {
                var dataTable = new DataTable();

                var data = multi.Read();
                if (data == null || !data.AsList().Any())
                {
                    continue;
                }

                var firstRow = (IDictionary<string, object>)data.First();
                foreach (var key in firstRow.Keys)
                {
                    dataTable.Columns.Add(key);
                }

                foreach (var row in data)
                {
                    var dataRow = dataTable.NewRow();
                    foreach (var key in firstRow.Keys)
                    {
                        dataRow[key] = ((IDictionary<string, object>)row)[key] ?? DBNull.Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }

                dataSet.Tables.Add(dataTable);
            }

            return dataSet;
        }

        public async Task<List<Dictionary<string, object>>> GetDynamicResult(string storedProcName, CommandType commandType, DynamicParameters parameters, string conn_str)
        {
            var result = new List<Dictionary<string, object>>();

            using (var conn = GetConnection(conn_str))
            using (var command = new SqlCommand(storedProcName, conn))
            {
                command.CommandType = commandType;

                foreach (var paramName in parameters.ParameterNames)
                {
                    var paramValue = parameters.Get<dynamic>(paramName);
                    command.Parameters.AddWithValue(paramName, paramValue ?? DBNull.Value);
                }

                await conn.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                           // row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            var value = reader.IsDBNull(i) ? null : reader.GetValue(i);

                            if (value is decimal decimalValue)
                            {
                                // Round to 2 decimal places
                                value = Math.Round(decimalValue, 2);
                            }
                            else if (value is double doubleValue)
                            {
                                // Optional: round doubles too
                                value = Math.Round(doubleValue, 2);
                            }

                            row[reader.GetName(i)] = value;
                        }
                        result.Add(row);
                    }
                }
            }

            return result;
        }

    }
}
