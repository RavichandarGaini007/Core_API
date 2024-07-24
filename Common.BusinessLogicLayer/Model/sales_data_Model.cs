using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class sales_data_Model
    {
        public string invoice_no { get; set; }
        public string invoice_date { get; set; }
        public string irn { get; set; }
        public string po_number { get; set; }
        public string order_date { get; set; }
        public string sales_order_no { get; set; }
        public string state { get; set; }
        public string shipping_date { get; set; }
        public string supply_area { get; set; }
        public string seller_id { get; set; }
        public string seller_name { get; set; }
        public string seller_address1 { get; set; }
        public string seller_address2 { get; set; }
        public string seller_city { get; set; }
        public string seller_postal_code { get; set; }
        public string seller_tax_id { get; set; }
        public string buyer_ship_to_id { get; set; }
        public string buyer_ship_to_name { get; set; }
        public string buyer_ship_to_address1 { get; set; }
        public string buyer_ship_to_address2 { get; set; }
        public string buyer_ship_to_city { get; set; }
        public string buyer_ship_to_postal_code { get; set; }
        public string buyer_ship_to_tax_id { get; set; }
        public string buyer_sold_to_id { get; set; }
        public string buyer_sold_to_name { get; set; }
        public string buyer_sold_to_address1 { get; set; }
        public string buyer_sold_to_address2 { get; set; }
        public string buyer_sold_to_city { get; set; }
        public string buyer_sold_to_postal_code { get; set; }
        public string buyer_sold_to_tax_id { get; set; }
        public string salesman_name { get; set; }
        public string licence_no { get; set; }
        public decimal gross_taxable_amount { get; set; }
        public decimal tax1_amount { get; set; }
        public decimal tax2_amount { get; set; }
        public decimal tax3_amount { get; set; }
        public decimal discount_amount { get; set; }
        public decimal scheme_discount_amount { get; set; }
        public decimal adjustment_amount { get; set; }
        public decimal tcs_percent { get; set; }
        public decimal tcs_amount { get; set; }
        public decimal net_payable { get; set; }
        public string company_name { get; set; }
        public List<PurchaseSalesItemModel> items { get; set; }

    }
    public class PurchaseSalesItemModel
    {
        public string supplier_id { get; set; }
        public string supplier_name { get; set; }
        public string article_code { get; set; }
        public string article_description { get; set; }
        public string hsn { get; set; }
        public string ean { get; set; }
        public string batch { get; set; }
        public int qty { get; set; }
        public int qty_free { get; set; }
        public string uom { get; set; }
        public decimal seller_base_price { get; set; }
        public decimal mrp { get; set; }
        public decimal scheme_discount_amount { get; set; }
        public decimal tax1_percent { get; set; }
        public decimal tax1_amount { get; set; }
        public decimal tax2_percent { get; set; }
        public decimal tax2_amount { get; set; }
        public decimal tax3_percent { get; set; }
        public decimal tax3_amount { get; set; }
        public decimal tax_amount { get; set; }
        public decimal item_total_amount { get; set; }
        public decimal net_price { get; set; }
    }



}
