using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model.GenericDashboard
{
    public class billingPendingOrderReportRes
    {
        public string Plant { get; set; }
        public string PlantName { get; set; }
        public string DivisionId { get; set; }
        public string Division { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public string PoNumber { get; set; }
        public string Material { get; set; }
        public string MaterialDescription { get; set; }
        public decimal? OrderQuantity { get; set; }
        public decimal? FreeQuantity { get; set; }
        public decimal? OrderAmount { get; set; }
        public decimal? UnconfirmedQuantity { get; set; }
        public decimal? UnconfirmedBonusQuantity { get; set; }
        public decimal? UnconfirmedValue { get; set; }
        public decimal? InvoiceQuantity { get; set; }
        public decimal? InvoiceFreeQuantity { get; set; }
        public decimal? InvoiceValue { get; set; }
        public decimal? TaxValue { get; set; }
        public string DeliveryDoc { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string BillingDoc { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string GatepassNumber { get; set; }
        public DateTime? GatepassDate { get; set; }
        public string LrNumber { get; set; }
        public DateTime? LrDate { get; set; }
        public int? NumberOfCases { get; set; }
    }
}
