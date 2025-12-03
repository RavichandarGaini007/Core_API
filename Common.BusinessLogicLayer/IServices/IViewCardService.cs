using Common.BusinessLogicLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.IServices
{
    public interface IViewCardService
    {
        public Task<ResponseModel> check_EmpStatus(string empcode);
        public Task<ResponseModel> employee_Details(string empcode);
        public Task<ResponseModel> brand_details(string empcode);
        public Task<ResponseModel> generic_brand_Details(string type);
        public Task<ResponseModel> Get_Invoice_Pdf(string invoiceno);
        public Task<ResponseModel> GetbrandhospitalProduct();
    }
}
