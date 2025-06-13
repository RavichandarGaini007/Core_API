using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Common.DataAccessLayer;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Dapper.SqlMapper;
using static System.Net.Mime.MediaTypeNames;

namespace Common.BusinessLogicLayer
{
    public class ViewCardService : IViewCardService
    {
        CommonServices commonServices = new CommonServices();
        private readonly IDAL _idal;
        private readonly IConfiguration _configuration;
        public ViewCardService(IDAL dAL, IConfiguration configuration)
        {
            _idal = dAL;
            _configuration = configuration;
        }
        public async Task<ResponseModel> check_EmpStatus(string empcode)
        {
            try
            {

                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@emp_code", empcode);
                var response = await _idal.GetIEnumerableData<checkEmpStatus>("sp_check_empcode_status", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sap_fgrn");
                string status = response.FirstOrDefault().status;
                return new ResponseModel
                {
                    Code = 1,
                    Data = status,
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

            //Task<IEnumerable<UserModel>> elist =  _idal.GetIEnumerableData<UserModel>("select * from Employee", CommandType.Text, dynamicParameters, 30);
            return responseModel;
        }
        public async Task<ResponseModel> employee_Details(string empcode)
        {
            try
            {
                string key = _configuration.GetSection("EncryptionKey").Value ?? "Xhh09@tyu$#";
                if (empcode.Length > 6)
                {
                    empcode = commonServices.DecryptString(empcode, key);
                }


                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@emp_code", empcode);
                var response = await _idal.GetIEnumerableData<empDetails>("sp_get_employee_details", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sap_fgrn");
                int flag = 1;
                if (response.Count() == 0 || response.FirstOrDefault().status != "y")
                {
                    flag = 0;
                }
                else
                {
                    response.FirstOrDefault().profileimage = response.FirstOrDefault().profileimage != null ? (byte[])response.FirstOrDefault().profileimage : null;
                }

                return new ResponseModel
                {
                    Code = flag,
                    Data = response,
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

            //Task<IEnumerable<UserModel>> elist =  _idal.GetIEnumerableData<UserModel>("select * from Employee", CommandType.Text, dynamicParameters, 30);
            return responseModel;
        }
        public async Task<ResponseModel> brand_details(string empcode)
        {
            try
            {
                string key = _configuration.GetSection("EncryptionKey").Value ?? "Xhh09@tyu$#";
                if (empcode.Length > 6)
                {
                    empcode = commonServices.DecryptString(empcode, key);
                }
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@emp_code", empcode);
                var brand_code = await _idal.GetIEnumerableData<brandCode>("sp_get_employee_brands", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sap_fgrn");
                var brand_details = await _idal.GetIEnumerableData<brandDetails>("sp_get_employee_brands_details", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sap_fgrn");

                var response = (from code in brand_code
                                join details in brand_details
                                on code.brand_code equals details.brand_code
                                group details by new { code.brand_code, code.brand_name, code.imageurl } into brandGroup
                                select new final_brand_details
                                {
                                    brand = brandGroup.Key.brand_name,
                                    imageurl = brandGroup.Key.imageurl,
                                    products = brandGroup.Select(p => new list_products
                                    {
                                        product_name = p.product_name,
                                        composition = p.composition
                                    }).ToList()
                                }).ToList();

                return new ResponseModel
                {
                    Code = 1,
                    Data = response,
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

            //Task<IEnumerable<UserModel>> elist =  _idal.GetIEnumerableData<UserModel>("select * from Employee", CommandType.Text, dynamicParameters, 30);
            return responseModel;
        }
        public async Task<ResponseModel> generic_brand_Details()
        {
            try
            {
                string key = _configuration.GetSection("EncryptionKey").Value ?? "Xhh09@tyu$#";
                DynamicParameters queryParameters = new DynamicParameters();
                var brandDetailsList = await _idal.GetIEnumerableData<brandDetails>("sp_get_generic_brand", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sap_fgrn");

                //var response = brandDetailsList
                //    .GroupBy(b => new { b.brand_code, b.brand_name, b.imageurl })
                //    .Select(g => new final_brand_details
                //    {
                //        brand = g.Key.brand_name,
                //        imageurl = g.Key.imageurl,
                //        products = g.Select(p => new list_products
                //        {
                //            product_name = p.product_name,
                //            composition = p.composition
                //        }).ToList()
                //    }).ToList();

                return new ResponseModel
                {
                    Code = 1,
                    Data = brandDetailsList,
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

        public async Task<ResponseModel> Get_Invoice_Pdf(string invoiceno)
        {
            string apiUrl = "http://prod-ecc.alkemerp.com:8000/sap/opu/odata/sap/zsd_inv_pdf_srv/InvoiceDataSet?$filter=Invoice eq '" + invoiceno + "' and Inv_type eq 'PDF'&$expand=PdfDataSet";
            try
            {
                // Create an HttpClient instance
                using (HttpClient client = new HttpClient())
                {
                    // Send a GET request to the API endpoint

                    var plainTextBytes = Encoding.ASCII.GetBytes("itsd:Rdsk@6191");
                    string val = System.Convert.ToBase64String(plainTextBytes);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(plainTextBytes));


                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {

                        //Read the response content as a string
                        string xmlData = response.Content.ReadAsStringAsync().Result;

                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(xmlData);

                        // Create XmlNamespaceManager to handle the 'd' namespace
                        XmlNamespaceManager nsManager = new XmlNamespaceManager(doc.NameTable);
                        nsManager.AddNamespace("d", "http://schemas.microsoft.com/ado/2007/08/dataservices");

                        // Get the specific node <d:Raw> using XPath and namespace manager
                        XmlNode rawNode = doc.SelectSingleNode("//d:Raw", nsManager);


                        if (rawNode != null && !string.IsNullOrEmpty(Convert.ToString(rawNode.InnerText)))
                        {
                            byte[] pdfBytes = Convert.FromBase64String(Convert.ToString(rawNode.InnerText));

                            return new ResponseModel
                            {
                                Code = 1,
                                Data = pdfBytes,
                                Message = "Success"
                            };

                        }
                        else
                        {
                            return new ResponseModel
                            {
                                Code = 0,
                                Data = new ExceptionResponse { ErrorMessage = "File Not Found" },
                                Message = $"File Not Found"
                            };
                        }
                    }
                    else
                    {
                        return new ResponseModel
                        {
                            Code = 0,
                            Data = new ExceptionResponse { ErrorMessage = "Failed to call API" },
                            Message = $"Failed to call API"
                        };
                    }
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

            //Task<IEnumerable<UserModel>> elist =  _idal.GetIEnumerableData<UserModel>("select * from Employee", CommandType.Text, dynamicParameters, 30);
            return responseModel;
        }


        public async Task<ResponseModel> GetbrandhospitalProduct()
        {

            try
            {
              
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@category", "brand");

                DynamicParameters queryParametersd = new DynamicParameters();
                queryParametersd.Add("@category", "branddetails");
                var brand_code = await _idal.GetIEnumerableData<brandCode>("get_employee_brand_hospital", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sap_fgrn_64");
                var brand_details = await _idal.GetIEnumerableData<brandDetails>("get_employee_brand_hospital", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParametersd, conn_str: "sap_fgrn_64");

                var response = (from code in brand_code
                                join details in brand_details
                                on code.brand_code equals details.brand_code
                                group details by new { code.brand_code, code.brand_name, code.imageurl,code.division } into brandGroup
                                select new final_brand_details
                                {
                                    brand = brandGroup.Key.brand_name,
                                    imageurl = brandGroup.Key.imageurl,
                                    division=brandGroup.Key.division,
                                    products = brandGroup.Select(p => new list_products
                                    {
                                        product_name = p.product_name,
                                        composition = p.composition
                                    }).ToList()
                                }).ToList();

                return new ResponseModel
                {
                    Code = 1,
                    Data = response,
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

            //Task<IEnumerable<UserModel>> elist =  _idal.GetIEnumerableData<UserModel>("select * from Employee", CommandType.Text, dynamicParameters, 30);
            return responseModel;

        }
    }
}
