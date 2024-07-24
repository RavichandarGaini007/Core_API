using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class stockFieldModel
    {
        public string customer_code { get; set; }
        public string customer_name { get; set; }
        public string customer_postal_code { get; set; }
        public string customer_tax_id { get; set; }
        public string supplier_id { get; set; }
        public string article_code { get; set; }
        public string article_description { get; set; }
        public string batch { get; set; }
        public string mfg_date { get; set; }
        public string expiry_date { get; set; }
        public int qty { get; set; }
        public string uom { get; set; }
        public decimal mrp { get; set; }
        public decimal dlp_pre_tax { get; set; }
        public decimal dlp_post_tax { get; set; }
        public decimal rlp_pre_tax { get; set; }
        public decimal rlp_post_tax { get; set; }
        public string company_name { get; set; }
    }
}
