
using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Common.DataAccessLayer;
using Dapper;
using Login_API.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer
{
    internal class UserServices: IUserServices
    {
        private readonly IDAL _idal;
        public UserServices(IDAL dAL) { 
            _idal= dAL;
        }

        public async Task<ResponseModel>  User()
        {
            try
            {
                
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@EmpCode", "AmolD");
                var response = await _idal.GetIEnumerableData<UserModel>("get_userDetails", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);

                return new ResponseModel
                {
                    Code = 1,
                    Data = response,
                    Message = "Success"
                };
            }
            catch(Exception ex)
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

        public async Task<ResponseModel> UserList(int id)
        {
            try
            {

                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@id", id);
                var response = await _idal.GetIEnumerableData<userListModal>("sp_get_userlist", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);

                //var response_json =  JsonSerializer.Serialize(response);
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
        public async Task<ResponseModel> DeleteUserbyid(int id)
        {
            try
            {

                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@id", id);
                var response = await _idal.GetIEnumerableData<userListModal>("sp_delete_userlist_byid", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);

                //var response_json =  JsonSerializer.Serialize(response);
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
        public async Task<ResponseModel> GetUserDetailsById(int id)
        {
            try
            {
                 
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@id", id);
                var response = await _idal.GetIEnumerableData<userListModal>("sp_userlist_byid", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);

                //var response_json =  JsonSerializer.Serialize(response);
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
        public async Task<ResponseModel> UpdateUserList(userlistmodel newUserlistmodel)
        {
            try
            {

                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@id", newUserlistmodel.id);
                queryParameters.Add("@code", newUserlistmodel.code);
                queryParameters.Add("@name", newUserlistmodel.name);
                queryParameters.Add("@email", newUserlistmodel.email);
                queryParameters.Add("@phone", newUserlistmodel.phone);
                queryParameters.Add("@role", newUserlistmodel.role);
                var response = await _idal.GetIEnumerableData<userListModal>("sp_update_user_list", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);

                //var response_json =  JsonSerializer.Serialize(response);
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
        public async Task<ResponseModel> AddUser(addnewuser newUserlistmodel)
        {
            try
            {

                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@name", newUserlistmodel.name);
                queryParameters.Add("@email", newUserlistmodel.email);
                queryParameters.Add("@phone", newUserlistmodel.phone);
                queryParameters.Add("@role", newUserlistmodel.role);
                var response = await _idal.GetIEnumerableData<userListModal>("sp_add_new_user_list", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);

                //var response_json =  JsonSerializer.Serialize(response);
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

        public async Task<ResponseModel> LoginUser(string userName, string password)
        {
            try
            {

                DynamicParameters queryParameters = new DynamicParameters();
                //queryParameters.Add("@emailid", userName);
                //queryParameters.Add("@flag", "C");
                queryParameters.Add("@struname", userName);
                var response = await _idal.GetIEnumerableData<loginModel>("PL_Proc_fillsession", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);
                //var response = await _idal.GetIEnumerableData<loginModel>("proc_fill_sales_session", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);
                //var response_json =  JsonSerializer.Serialize(response);
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
        }

        public async Task<ResponseModel> SalesPortalData(salesModel _salesModel)
        {
            try
            {
                //@tbl_name = N'FTP_11_2023',@enetsale = N'''ALL''',@eplant = N'',@ehq = N'',@empcode = N'41406',@tgt_cop_flag = N''
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@tbl_name", _salesModel.tbl_name) ;
                queryParameters.Add("@enetsale", _salesModel.enetsale);
                queryParameters.Add("@eplant", _salesModel.eplant);
                queryParameters.Add("@ehq", _salesModel.ehq);
                queryParameters.Add("@empcode", _salesModel.empcode);
                queryParameters.Add("@tgt_cop_flag", _salesModel.tgt_cop_flag);
                var response = await _idal.GetIEnumerableData<sales_Model>("Proc_sales_portal_net_sales_main", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);

                //var response_json =  JsonSerializer.Serialize(response);
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
        }
        public async Task<ResponseModel> getEmailId(string emailid)
        {
            try
            {

                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@userid", emailid);
                var response = await _idal.GetIEnumerableData<loginModel>("getEmailId", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);

                //var response_json =  JsonSerializer.Serialize(response);
            
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
        }
    }
}
