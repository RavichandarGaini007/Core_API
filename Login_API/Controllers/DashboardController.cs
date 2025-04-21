using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace Login_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : Controller
    {
        private readonly IDashboardServices _dashServices;
        private IConfiguration _config;

        public DashboardController(IDashboardServices dashServices, IConfiguration config)
        {
            _dashServices = dashServices;
            _config = config;
        }

        [HttpPost]
        [Route("forecastData")]
        public async Task<ActionResult<ResponseModel>> getForecast(dash_comReqModel req)
        {
            var a = await _dashServices.getForecast(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("forecastDayWise")]
        public async Task<ActionResult<ResponseModel>> getForecast_DayWise(dash_comReqModel req)
        {
            var a = await _dashServices.getForecast_DayWise(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("PmtGmForecastUpload")]
        public async Task<ActionResult<ResponseModel>> getPmtGmForecastUpload(dash_comReqModel req)
        {
            var a = await _dashServices.getPmtGmForecastUpload(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("GmDepotTargetMaster")]
        public async Task<ActionResult<ResponseModel>> getGmDepotTargetMaster(dash_comReqModel req)
        {
            var a = await _dashServices.getGmDepotTargetMaster(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("NetSaleReport")]
        public async Task<ActionResult<ResponseModel>> getNetSaleReport(dash_comReqModel req)
        {
            var a = await _dashServices.getNetSaleReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("AginReport")]
        public async Task<ActionResult<ResponseModel>> getAginReport(dash_comReqModel req)
        {
            var a = await _dashServices.getAginReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("MonthWiseForecastReport")]
        public async Task<ActionResult<ResponseModel>> getMonthWiseForecastReport(dash_comReqModel req)
        {
            var a = await _dashServices.getMonthWiseForecastReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("ForecastEntryStatusReport")]
        public async Task<ActionResult<ResponseModel>> getForecastEntryStatusReport(dash_comReqModel req)
        {
            var a = await _dashServices.getForecastEntryStatusReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("ForecastDesgReport")]
        public async Task<ActionResult<ResponseModel>> getForecastDesgReport(dash_comReqModel req)
        {
            var a = await _dashServices.getForecastDesgReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("FinalSaleForecastReport")]
        public async Task<ActionResult<ResponseModel>> getFinalSaleForecastReport(dash_comReqModel req)
        {
            var a = await _dashServices.getFinalSaleForecastReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("FirstPriorityDispatchReport")]
        public async Task<ActionResult<ResponseModel>> getFirstPriorityDispatchReport(dash_comReqModel req)
        {
            var a = await _dashServices.getFirstPriorityDispatchReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("CfaOpeningReport")]
        public async Task<ActionResult<ResponseModel>> getCfaOpeningReport(dash_comReqModel req)
        {
            var a = await _dashServices.getCfaOpeningReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("BatchWiseReport")]
        public async Task<ActionResult<ResponseModel>> getBatchWiseReport(dash_comReqModel req)
        {
            var a = await _dashServices.getBatchWiseReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("CurrentWhStockReport")]
        public async Task<ActionResult<ResponseModel>> getCurrentWhStockReport(dash_comReqModel req)
        {
            var a = await _dashServices.getCurrentWhStockReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("InventoryReport")]
        public async Task<ActionResult<ResponseModel>> getInventoryReport(dash_comReqModel req)
        {
            var a = await _dashServices.getInventoryReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("AginMonthReport")]
        public async Task<ActionResult<ResponseModel>> getAginMonthReport(dash_comReqModel req)
        {
            var a = await _dashServices.getAginMonthReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("InventorySummeryReport")]
        public async Task<ActionResult<ResponseModel>> getInventorySummeryReport(dash_comReqModel req)
        {
            var a = await _dashServices.getInventorySummeryReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("TargetPlanUploadData")]
        public async Task<ActionResult<ResponseModel>> getTargetPlanUploadData(dash_comReqModel req)
        {
            var a = await _dashServices.getTargetPlanUploadData(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("DivWiseReport")]
        public async Task<ActionResult<ResponseModel>> getDivWiseReport(dash_comReqModel req)
        {
            var a = await _dashServices.getDivWiseReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("DepotMasterSheetReport")]
        public async Task<ActionResult<ResponseModel>> getDepotMasterSheetReport(dash_comReqModel req)
        {
            var a = await _dashServices.getDepotMasterSheetReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("DepotWiseReport")]
        public async Task<ActionResult<ResponseModel>> getDepotWiseReport(dash_comReqModel req)
        {
            var a = await _dashServices.getDepotWiseReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("SkuBrandWiseReport")]
        public async Task<ActionResult<ResponseModel>> getSkuBrandWiseReport(dash_comReqModel req)
        {
            var a = await _dashServices.getSkuBrandWiseReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("NewProductPerfmReport")]
        public async Task<ActionResult<ResponseModel>> getNewProductPerfmReport(dash_comReqModel req)
        {
            var a = await _dashServices.getNewProductPerfmReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("CriticalOSReoport")]
        public async Task<ActionResult<ResponseModel>> getCriticalOSReoport(dash_comReqModel req)
        {
            var a = await _dashServices.getCriticalOSReoport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("HqWiseReport")]
        public async Task<ActionResult<ResponseModel>> getHqWiseReport(dash_comReqModel req)
        {
            var a = await _dashServices.getHqWiseReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("HqSkuWiseReport")]
        public async Task<ActionResult<ResponseModel>> getHqSkuWiseReport(dash_comReqModel req)
        {
            var a = await _dashServices.getHqSkuWiseReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("HqBrandWiseReport")]
        public async Task<ActionResult<ResponseModel>> getHqBrandWiseReport(dash_comReqModel req)
        {
            var a = await _dashServices.getHqBrandWiseReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("NearExpiryReport")]
        public async Task<ActionResult<ResponseModel>> getNearExpiryReport(dash_comReqModel req)
        {
            var a = await _dashServices.getNearExpiryReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("DivPerfmReport")]
        public async Task<ActionResult<ResponseModel>> getDivPerfmReport(dash_comReqModel req)
        {
            var a = await _dashServices.getDivPerfmReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("SkuPerfmReport")]
        public async Task<ActionResult<ResponseModel>> getSkuPerfmReport(dash_comReqModel req)
        {
            var a = await _dashServices.getSkuPerfmReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("BrandPerfmReport")]
        public async Task<ActionResult<ResponseModel>> getBrandPerfmReport(dash_comReqModel req)
        {
            var a = await _dashServices.getBrandPerfmReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("BulkMailReport")]
        public async Task<ActionResult<ResponseModel>> getBulkMailReport(dash_comReqModel req)
        {
            var a = await _dashServices.getBulkMailReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("updateNetSale")]
        public async Task<ActionResult<ResponseModel>> updateNetSale(dash_comReqModel req)
        {
            var a = await _dashServices.updateNetSale(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("ProductMaster")]
        public async Task<ActionResult<ResponseModel>> getProductMaster(dash_comReqModel req)
        {
            var a = await _dashServices.getProductMaster(req);
            return Ok(a);
        }


        /// <summary>
        /// S. S Billing Start
        /// </summary>


        [HttpPost]
        [Route("SsOrderEntry")]
        public async Task<ActionResult<ResponseModel>> getBillingOrderEntry(billing_comReqModel req)
        {
            var a = await _dashServices.getBillingOrderEntry(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("SsOrderEntryIns")]
        public async Task<ActionResult<ResponseModel>> getBillingInsOrderEntry(billing_comReqModel req)
        {
            var a = await _dashServices.getBillingInsOrderEntry(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("SsOrderEntryMod")]
        public async Task<ActionResult<ResponseModel>> getBillingOrderEntryMod(billing_comReqModel req)
        {
            var a = await _dashServices.getBillingOrderEntryMod(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("SsOrderEntryModExcel")]
        public async Task<ActionResult<ResponseModel>> getBillingOrderEntryModExcel(billing_comReqModel req)
        {
            var a = await _dashServices.getBillingOrderEntryModExcel(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("SsOrderApproval")]
        public async Task<ActionResult<ResponseModel>> getBillingApprovalOrder(billing_comReqModel req)
        {
            var a = await _dashServices.getBillingApprovalOrder(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("SsOrderApproveOne")]
        public async Task<ActionResult<ResponseModel>> getBillingApprovalOneOrder(billing_comReqModel req)
        {
            var a = await _dashServices.getBillingApprovalOneOrder(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("SsOrderProductApproval")]
        public async Task<ActionResult<ResponseModel>> getBillingProductApprovalOrder(billing_comReqModel req)
        {
            var a = await _dashServices.getBillingProductApprovalOrder(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("SsApprovedOrder")]
        public async Task<ActionResult<ResponseModel>> getBillingApprovedOrder(billing_comReqModel req)
        {
            var a = await _dashServices.getBillingApprovedOrder(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("SsOrderPushSap")]
        public async Task<ActionResult<ResponseModel>> getBillingPushToSapOrder(billing_comReqModel req)
        {
            var a = await _dashServices.getBillingPushToSapOrder(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("SsSapOrderStatus")]
        public async Task<ActionResult<ResponseModel>> getBillingSapOrderStatus(billing_comReqModel req)
        {
            var a = await _dashServices.getBillingSapOrderStatus(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("SsOrderEntryReport")]
        public async Task<ActionResult<ResponseModel>> getBillingOrderEntryReport(billing_comReqModel req)
        {
            var a = await _dashServices.getBillingOrderEntryReport(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("SsPendingOrderReport")]
        public async Task<ActionResult<ResponseModel>> getBillingPendingOrder(billing_comReqModel req)
        {
            var a = await _dashServices.getBillingPendingOrder(req);
            return Ok(a);
        }

    }
}
