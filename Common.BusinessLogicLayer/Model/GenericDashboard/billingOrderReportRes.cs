using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model.GenericDashboard
{
    public class billingOrderReportRes
    {
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string DivId { get; set; }
        public string DivName { get; set; }
        public string PlantCode { get; set; }
        public string PlantName { get; set; }
        public string CustId { get; set; }
        public string CustName { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string PTD { get; set; }
        public decimal OrderQtyShipper { get; set; }
        public decimal ApprovedQty { get; set; }
        public string OrderQtyUnits { get; set; }
        public decimal OrderValue { get; set; }
        public decimal TotalWeight { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string OrderEnteredBy { get; set; }
        public DateTime OrderEnteredDate { get; set; }
        public string StockiestApprovedBy { get; set; }
        public DateTime StockiestApprovedDate { get; set; }
        public string StockiestApprovedRemarks { get; set; }
        public string ManagerApprovedBy { get; set; }
        public DateTime ManagerApprovedDate { get; set; }
        public string ManagerApprovedRemarks { get; set; }
        public string LogisticApprovedBy { get; set; }
        public DateTime LogisticApprovedDate { get; set; }
        public string LogisticApprovedRemarks { get; set; }
        public string ProductRejectBy { get; set; }
        public DateTime ProductRejectDate { get; set; }
        public string OrderType { get; set; }
    }
}
