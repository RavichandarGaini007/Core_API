using Common.BusinessLogicLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.IServices
{
    public interface IPurchaseSaleService
    {
        public Task<ResponseModel> getPurchaseSale(purchaseModel _purchaseModel);
        public Task<ResponseModel> getSalesFields(sales_data_Model sales_Data_Model);
        public Task<ResponseModel> getStock(stockFieldModel stockFieldModel);
        public Task<ResponseModel> getToken(string userName,string password);
    }
}
