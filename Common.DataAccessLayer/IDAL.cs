using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Common.DataAccessLayer
{
    public interface IDAL
    {
        Task<GridReader> RunMultipleQueryAsync(string query, CommandType commandType,  DynamicParameters parameters = null, string conn_str = null);
        Task<IEnumerable<T>> GetIEnumerableData<T>(string query, CommandType commandType,  DynamicParameters parameters = null,string conn_str=null, int timeOut = 30) where T : class;
        Task<T> GetData<T>(string query, CommandType commandType,  DynamicParameters parameters = null, string conn_str = null) where T : class;
        Task<int> ExecuteQuery(string query, CommandType commandType = CommandType.StoredProcedure,  DynamicParameters parameters = null, string conn_str = null);

        Task<int> GetScalarData(string query, CommandType commandType = CommandType.StoredProcedure,  DynamicParameters parameters = null, string conn_str = null);
        Task<string> GetScalarStringData(string query, CommandType commandType = CommandType.StoredProcedure,  DynamicParameters parameters = null, string conn_str = null);
        Task<DataTable> GetDataTable<T>(string query, CommandType commandType, DynamicParameters parameters = null, string conn_str = null) where T : class;
        Task<DataSet> GetDataSet<T>(string query, CommandType commandType, DynamicParameters parameters = null, string conn_str = null) where T : class;

        Task<List<Dictionary<string, object>>> GetDynamicResult(string storedProcName, CommandType commandType, DynamicParameters parameters, string conn_str);

    }
}
