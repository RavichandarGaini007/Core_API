using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model.GenericDashboard
{
    public class billingPushToSapRes
    {
        public string Customer { get; set; }
        public string Plant { get; set; }
        public string SalesDocumentPharmarackOrderNo { get; set; }
        public string Product { get; set; }
        public string PlantName { get; set; }
        public string CustomerName { get; set; }
        public string CustReferenceNo { get; set; }
        public string Remarks { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public int Items { get; set; }
        public string Flag { get; set; }
        public string OrderType { get; set; }
        public string Rate { get; set; }
    }
}
