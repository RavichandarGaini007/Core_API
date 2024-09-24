using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Common.DataAccessLayer;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using static System.Net.Mime.MediaTypeNames;

namespace Common.BusinessLogicLayer
{
    public class ViewCardService : IViewCardService
    {
        CommonServices commonServices = new CommonServices();
        private readonly IDAL _idal;
        private readonly IConfiguration _configuration;
        public ViewCardService(IDAL dAL,IConfiguration configuration)
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
                string status=response.FirstOrDefault().status;
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
                empcode = commonServices.DecryptString(empcode, key);

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
                empcode = commonServices.DecryptString(empcode, key);
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@emp_code", empcode);
                var brand_code = await _idal.GetIEnumerableData<brandCode>("sp_get_employee_brands", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sap_fgrn");
                var brand_details = await _idal.GetIEnumerableData<brandDetails>("sp_get_employee_brands_details", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sap_fgrn");

                var response = (from code in brand_code
                                          join details in brand_details
                                          on code.brand_code equals details.brand_code
                                          group details by new { code.brand_code, code.brand_name } into brandGroup
                                          select new final_brand_details
                                          {
                                              brand = brandGroup.Key.brand_name,
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
