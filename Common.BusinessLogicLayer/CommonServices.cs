using Common.BusinessLogicLayer.Model.GenericDashboard;
using Common.BusinessLogicLayer.Model;
using Common.DataAccessLayer;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Reflection;
using Common.BusinessLogicLayer.IServices;
using System.Data.SqlClient;

namespace Common.BusinessLogicLayer
{
    public class CommonServices : ICommonServices
    {
        private readonly IDAL _idal;

        public CommonServices()
        {
        }
        public CommonServices(IDAL dAL)
        {
            _idal = dAL;
        }

        public  string DecryptString(string clearText, string key)
        {
            byte[] cipherBytes = Convert.FromBase64String(clearText);
            using (Aes decryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }); decryptor.Key = pdb.GetBytes(32); decryptor.IV = pdb.GetBytes(16); using (MemoryStream ms = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] clearBytes = new byte[cipherBytes.Length];
                        int bytesDecrypted = cs.Read(clearBytes, 0, clearBytes.Length);
                        return Encoding.UTF8.GetString(clearBytes, 0, bytesDecrypted);

                    }
                }
            }
        }

        public async Task<ResponseModel> fgrnEntry(fgrnReqModel req, string uname, string pass)
        {
            try
            {
                var status_code = 0;
                var queryParameters1 = new DynamicParameters();
                queryParameters1.Add("@userName", uname);
                queryParameters1.Add("@password", pass);
                var response = await _idal.GetIEnumerableData<TokenModel>("sp_check_token_val", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters1, conn_str: "alk_common");

                if (response.FirstOrDefault().Application_Name == uname && response.FirstOrDefault().Secret_Key == pass)
                {

                    DynamicParameters queryParameters = new DynamicParameters();

                    DataTable reqdt = FlattenToDataTable(req);

                    queryParameters.Add("@tblFgrnEntryType", reqdt, dbType: DbType.Object, direction: ParameterDirection.Input);

                    var responseFinal = await _idal.GetIEnumerableData<fgrnResModel>("proc_fgrn_entry_api", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sap_fgrn");

                    return new ResponseModel
                    {
                        Code = 1,
                        Data = responseFinal,
                        Message = "Success"
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Code = 0,
                        Data = new ExceptionResponse { ErrorMessage = $"Invalid Username and password " },
                        Message = $"Invalid Username and password "
                    };
                }


                
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Code = 0,
                    Data = new ExceptionResponse { ErrorMessage = $"Error occured while fetching data : {ex.Message}" },
                    Message = $"Error : {ex.Message}"
                };
            }
            ResponseModel responseModel = new ResponseModel();

            return responseModel;
        }

        public static DataTable FlattenToDataTable<T>(T obj)
        {
            DataTable table = new DataTable(typeof(T).Name);

            // Get all properties of the main object
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Find the first property that is a list (nested objects)
            PropertyInfo listProp = props.FirstOrDefault(p => typeof(IEnumerable).IsAssignableFrom(p.PropertyType) && p.PropertyType != typeof(string));

            // Header columns = all non-list properties
            var headerProps = listProp != null ? props.Where(p => p != listProp) : props;

            foreach (var prop in headerProps)
            {
                //Type colType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                table.Columns.Add(prop.Name, typeof(string));
            }

            // If there is a nested list, add its columns
            Type listItemType = listProp?.PropertyType.GetGenericArguments()[0];
            PropertyInfo[] listProps = listItemType?.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            if (listProps != null)
            {
                foreach (var prop in listProps)
                {
                    //Type colType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    table.Columns.Add(prop.Name, typeof(string));
                }
            }

            // Get the list of items from the nested list
            IEnumerable nestedList = listProp?.GetValue(obj) as IEnumerable;

            // If there is a nested list, create one row per nested item
            if (nestedList != null)
            {
                foreach (var item in nestedList)
                {
                    DataRow row = table.NewRow();

                    // Fill header columns
                    foreach (var prop in headerProps)
                    {
                        row[prop.Name] = prop.GetValue(obj).ToString().Trim() ?? "";
                    }

                    // Fill nested columns
                    foreach (var prop in listProps)
                    {
                        row[prop.Name] = prop.GetValue(item).ToString().Trim() ?? "";
                    }

                    table.Rows.Add(row);
                }
            }
            else
            {
                // If no nested list, just add one row
                DataRow row = table.NewRow();
                foreach (var prop in headerProps)
                {
                    row[prop.Name] = prop.GetValue(obj).ToString().Trim() ?? "";
                }
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
