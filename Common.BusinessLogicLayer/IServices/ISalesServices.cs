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

        public Task<ResponseModel> getBrandCodeFromFlatFile(string div, string year);
        public Task<ResponseModel> getFlatFilePrimarySales(string DownloadFor, string year, string empcode, string div, string brand_code);

    }
}
