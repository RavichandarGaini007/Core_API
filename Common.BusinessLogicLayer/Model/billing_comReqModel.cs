using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class billing_comReqModel
    {
        public string? Div { get; set; }
        public string? Depot { get; set; }
        public string? cust_emailId { get; set; }
        public string? flag { get; set; }
        public string? orderNo { get; set; }
        public string? role { get; set; }
        public string? user_Id { get; set; }
        public string? pageFlag { get; set; }
        public string? status { get; set; }
        public string? product { get; set; }
        public decimal? OrderQty { get; set; }
        public decimal? OrderUnits { get; set; }
        public decimal? OrderValue { get; set; }
        public decimal? OrderWeight { get; set; }
        public string? strRemarks { get; set; }
        public string? strProdStatus { get; set; }
        public string? txtProdRemarks { get; set; }
        public string? mailStatus { get; set; }
        public string? sapStatus { get; set; }
        public string? cust_id { get; set; }
        public string? OrderFrom { get; set; }
        public string? OrderTo { get; set; }
        public string? month { get; set; }
        public string? year { get; set; }
    }
}
