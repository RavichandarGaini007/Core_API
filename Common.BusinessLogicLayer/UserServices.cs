
using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Common.DataAccessLayer;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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

      
    }
}
