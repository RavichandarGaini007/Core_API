using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Common.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.BusinessLogicLayer
{

    public class ChatbotService : IChatbotService
    {
        private readonly IDAL _idal;
        public readonly HttpClient _http;
        private readonly string _endpointWithKey;
        string tableName, matTableName, qtyTableName, userQuestion;

        public ChatbotService(HttpClient http, IConfiguration config, IDAL dAL)
        {
            _http = http;
            _idal = dAL;

            var url = config["GenerativeLanguage:Url"];
            var key = config["GenerativeLanguage:ApiKey"];

            if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(key))
            {
                throw new InvalidOperationException("GenerativeLanguage:Url and GenerativeLanguage:ApiKey must be configured.");
            }

            _endpointWithKey = $"{url}?key={WebUtility.UrlEncode(key)}";
        }

        // Helper: convert DataTable to serializable list
        private static List<Dictionary<string, object>> DataTableToList(DataTable table)
        {
            var rows = new List<Dictionary<string, object>>();
            if (table == null) return rows;
            foreach (DataRow dr in table.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    var val = dr[col];
                    dict[col.ColumnName] = val == DBNull.Value ? null : val;
                }
                rows.Add(dict);
            }
            return rows;
        }

        // Helper: convert DataSet to serializable dictionary
        private static Dictionary<string, object> DataSetToObject(DataSet ds)
        {
            var result = new Dictionary<string, object>();
            if (ds == null) return result;
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                var table = ds.Tables[i];
                result[table.TableName ?? $"Table{i}"] = DataTableToList(table);
            }
            return result;
        }

        public async Task<ResponseModel> GenerateSqlAsync(ChatbotReq req)
        {
            try
            {
                tableName = req.tbl_name;
                matTableName = req.tbl_name.Replace("FTP_", "FTP_MAT_VAL_");
                qtyTableName = req.tbl_name.Replace("FTP_", "FTP_QTY_VAL_");
                userQuestion = req.userQuestion.Replace("plant", "werks").Replace("hq", "vkbur").Replace("div", "division");


                if (string.IsNullOrWhiteSpace(tableName)) throw new ArgumentException("tableName is required", nameof(tableName));
                req.userQuestion ??= "Show sales of this month for 01 division and 1902 werks";

                var prompt = $@"
                You are a SQL Server expert. Generate ONLY SQL Server SELECT query. Rules: Never generate INSERT, 
                UPDATE, DELETE, DROP, ALTER. Use only given tables. Database tables: {tableName} purpose Customer 
                wise sales columns division,name,werks,plant,vkbur,bezei,kunnr,name1,sale,netsales,target,Month,
                Year. {matTableName} purpose Product wise sales value columns division,name,plant,pname,vkbur,bezei,
                matnr,maktx,brand,sale,netsales,target,month,year. {qtyTableName} purpose Product wise quantity 
                columns division,name,plant,pname,vkbur,bezei,matnr,maktx,brand,freeqty,sale,month,year. Return SQL only. 
                User Question:{userQuestion}
                ";

                var payload = new
                {
                    contents = new[]
                    {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
                };

                var json = JsonSerializer.Serialize(payload);
                using var request = new HttpRequestMessage(HttpMethod.Post, _endpointWithKey)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                using var response = await _http.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                using var doc = JsonDocument.Parse(responseJson);
                // navigate: candidates[0].content.parts[0].text
                if (!doc.RootElement.TryGetProperty("candidates", out var candidates) ||
                    candidates.GetArrayLength() == 0)
                    return new ResponseModel
                    {
                        Code = 0,
                        Data = new ExceptionResponse { ErrorMessage = $"wrong response received " },
                        Message = $"Error"
                    };

                var text = candidates[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text")
                    .GetString() ?? string.Empty;

                // Remove Markdown code fences and trim
                text = Regex.Replace(text.Replace("\n", " "), @"^```(?:sql)?\s*|\s*```$", "", RegexOptions.IgnoreCase).Trim();

                // call DAL - get raw object
                var raw = await _idal.GetDataTable<object>(
                           text,
                           commandType: CommandType.Text,
                           conn_str: "sms_database"
                       );

                object serializableData = null;

                if (raw is DataTable dt)
                {
                    serializableData = DataTableToList(dt);
                }
                else
                {
                    // fallback: try to convert known ADO.NET types or return raw
                    serializableData = raw;
                }

                return new ResponseModel
                {
                    Code = 1,
                    Data = serializableData,
                    Message = "Success"
                };
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
    }
}
