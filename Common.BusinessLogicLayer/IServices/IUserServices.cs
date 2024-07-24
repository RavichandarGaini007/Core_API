
using Common.BusinessLogicLayer.Model;
using Login_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.IServices
{
    public interface IUserServices
    {
        public Task<ResponseModel> User();
        public Task<ResponseModel> UserList(int id);
        public Task<ResponseModel> DeleteUserbyid(int id);
        public Task<ResponseModel> GetUserDetailsById(int id);

        public Task<ResponseModel> UpdateUserList(userlistmodel userlistmodel);
        public Task<ResponseModel> AddUser(addnewuser addnewuser);
        public Task<ResponseModel> LoginUser(string userName, string password);
        public Task<ResponseModel> SalesPortalData(salesModel _salesModel);
        public Task<ResponseModel> getEmailId(string emailid);
    }
}
