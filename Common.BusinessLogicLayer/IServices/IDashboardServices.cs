using Common.BusinessLogicLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.IServices
{
    public interface IDashboardServices
    {
        public Task<ResponseModel> getForecast(dash_comReqModel req);
        public Task<ResponseModel> getForecast_DayWise(dash_comReqModel req);
        public Task<ResponseModel> getPmtGmForecastUpload(dash_comReqModel req);
        public Task<ResponseModel> getGmDepotTargetMaster(dash_comReqModel req);
        public Task<ResponseModel> getNetSaleReport(dash_comReqModel req);
        public Task<ResponseModel> getAginReport(dash_comReqModel req);
        public Task<ResponseModel> getMonthWiseForecastReport(dash_comReqModel req);
        public Task<ResponseModel> getForecastEntryStatusReport(dash_comReqModel req);
        public Task<ResponseModel> getForecastDesgReport(dash_comReqModel req);
        public Task<ResponseModel> getFinalSaleForecastReport(dash_comReqModel req);
        public Task<ResponseModel> getFirstPriorityDispatchReport(dash_comReqModel req);
        public Task<ResponseModel> getCfaOpeningReport(dash_comReqModel req);
        public Task<ResponseModel> getBatchWiseReport(dash_comReqModel req);
        public Task<ResponseModel> getCurrentWhStockReport(dash_comReqModel req);
        public Task<ResponseModel> getInventoryReport(dash_comReqModel req);
        public Task<ResponseModel> getAginMonthReport(dash_comReqModel req);
        public Task<ResponseModel> getInventorySummeryReport(dash_comReqModel req);
        public Task<ResponseModel> getTargetPlanUploadData(dash_comReqModel req);
        public Task<ResponseModel> getDivWiseReport(dash_comReqModel req);
        public Task<ResponseModel> getDepotMasterSheetReport(dash_comReqModel req);
        public Task<ResponseModel> getDepotWiseReport(dash_comReqModel req);
        public Task<ResponseModel> getSkuBrandWiseReport(dash_comReqModel req);
        public Task<ResponseModel> getNewProductPerfmReport(dash_comReqModel req);
        public Task<ResponseModel> getCriticalOSReoport(dash_comReqModel req);
        public Task<ResponseModel> getHqWiseReport(dash_comReqModel req);
        public Task<ResponseModel> getHqSkuWiseReport(dash_comReqModel req);
        public Task<ResponseModel> getHqBrandWiseReport(dash_comReqModel req);
        public Task<ResponseModel> getNearExpiryReport(dash_comReqModel req);
        public Task<ResponseModel> getDivPerfmReport(dash_comReqModel req);
        public Task<ResponseModel> getSkuPerfmReport(dash_comReqModel req);
        public Task<ResponseModel> getBrandPerfmReport(dash_comReqModel req);
        public Task<ResponseModel> getBulkMailReport(dash_comReqModel req);
        public Task<ResponseModel> updateNetSale(dash_comReqModel req);
        public Task<ResponseModel> getProductMaster(dash_comReqModel req);



        public Task<ResponseModel> getBillingOrderEntry(billing_comReqModel req);
        public Task<ResponseModel> getBillingInsOrderEntry(billing_comReqModel req);
        public Task<ResponseModel> getBillingOrderEntryMod(billing_comReqModel req);
        public Task<ResponseModel> getBillingOrderEntryModExcel(billing_comReqModel req);
        public Task<ResponseModel> getBillingApprovalOrder(billing_comReqModel req);
        public Task<ResponseModel> getBillingApprovalOneOrder(billing_comReqModel req);
        public Task<ResponseModel> getBillingProductApprovalOrder(billing_comReqModel req);
        public Task<ResponseModel> getBillingApprovedOrder(billing_comReqModel req);
        public Task<ResponseModel> getBillingPushToSapOrder(billing_comReqModel req);
        public Task<ResponseModel> getBillingSapOrderStatus(billing_comReqModel req);
        public Task<ResponseModel> getBillingOrderEntryReport(billing_comReqModel req);
        public Task<ResponseModel> getBillingPendingOrder(billing_comReqModel req);


    }
}
