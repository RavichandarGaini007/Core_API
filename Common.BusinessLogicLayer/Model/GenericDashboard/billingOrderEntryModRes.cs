using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model.GenericDashboard
{
    public class billingOrderEntryModRes
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
        public decimal Ptd { get; set; }
        public int ShipperQty { get; set; }
        public decimal ShipperWt { get; set; }
        public int OrderQtyShipper { get; set; }
        public int OrderQtyUnits { get; set; }
        public decimal OrderValue { get; set; }
        public decimal TotalWeight { get; set; }
        public string Remarks { get; set; }
        public string ProductRemarks { get; set; }
        public string Status { get; set; }
    }
}
