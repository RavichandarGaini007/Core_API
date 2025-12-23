using Common.BusinessLogicLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.IServices
{
    public interface ISalesServices
    {
        public Task<ResponseModel> getSalesData(salesComReqModel req);
        public Task<ResponseModel> getSalesAchvdata(salesComReqModel req);
        public Task<ResponseModel> getSalesTblWidges(salesComReqModel req);
        public Task<ResponseModel> getSalesTopPerformance(salesComReqModel req);
        public Task<ResponseModel> getSalesHierarchyDesg(salesComReqModel req);
        public Task<ResponseModel> getSalesDivHQ(salesComReqModel req);
        public Task<ResponseModel> getSalesScData(salesComReqModel req);
        public Task<ResponseModel> getSalesEmpAllDesg(string EmpCode);
        public Task<ResponseModel> getSalesDiv(string EmpCode);
        public Task<ResponseModel> getBrandPerfmnceData(salesComReqModel req);
        public Task<ResponseModel> getDivHqReportData(salesComReqModel req);
        public Task<ResponseModel> getDivBrandReportData(salesComReqModel req);
        public Task<ResponseModel> getDivPlantReportData(salesComReqModel req);
        public Task<ResponseModel> getDivCustReportData(salesComReqModel req);
        public Task<ResponseModel> getRegionReportData(salesComReqModel req);
        public Task<ResponseModel> getProductReportData(salesComReqModel req);
        public Task<ResponseModel> LoginUser(string userName, string password);
        public Task<ResponseModel> getMenu(string empCode, string role);

        public Task<ResponseModel> getBrandCodeFromFlatFile(string div, string year, string screencode,string fieldname, string brandcode,string userid);
        public Task<ResponseModel> getFlatFilePrimarySales(string DownloadFor, string year, string empcode, string div, string brand_code);
        public Task<ResponseModel> getCustomize_tab_user(string userid);

        public Task<ResponseModel> getFtpDetails(string Name);
        public Task<ResponseModel> GetDesGetDesgEmp(string division, string userid, string flag, string designation, string accesstype);

        public Task<ResponseModel> NetworkWiseProductSale_S(string div, string desg, string Misdesc, string plant, string brand, string product, string month, string year, string type);

    }
}
