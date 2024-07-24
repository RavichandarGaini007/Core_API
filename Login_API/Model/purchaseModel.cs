using System;

namespace Login_API.Model
{
    public class purchaseModel
    {
        public string invoice_number { get; set; }
        public string grn_no { get; set; }
        public string order_date { get; set; }
        public string delivery_date { get; set; }
        public string expiry_date { get; set; }
        public string order_type_value { get; set; }
        public string supplier_id { get; set; }
        public string supplier_name { get; set; }
        public string supplier_ship_from_id { get; set; }
        public string supplier_ship_from_name { get; set; }
        public string supplier_ship_from_address1 { get; set; }
        public string supplier_ship_from_address2 { get; set; }
        public string supplier_ship_from_city { get; set; }
        public string supplier_ship_from_postal_code { get; set; }
        public string supplier_ship_from_tax_id { get; set; }
        public string supplier_bill_from_name { get; set; }
        public string supplier_bill_from_address1 { get; set; }
        public string supplier_bill_from_address2 { get; set; }
        public string supplier_bill_from_city { get; set; }
        public string supplier_bill_from_postal_code { get; set; }
        public string supplier_bill_from_tax_id { get; set; }


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

        public decimal total_tax1_amount { get; set; }
        public decimal total_tax2_amount { get; set; }
        public decimal total_tax3_amount { get; set; }
        public decimal discount_amount { get; set; }
        public decimal scheme_discount_amount { get; set; }
        public decimal adjustment_amount { get; set; }
        public decimal cess_percent { get; set; }
        public decimal cess_amount { get; set; }
        public decimal total_amount { get; set; }
        public string currency { get; set; }
        public List<InvoiceItem> invoice_items { get; set; }
    }
    public class InvoiceItem
    {
        public string invoice_number { get; set; }
        public int item_no { get; set; }
        public string batch { get; set; }
        public string item_category { get; set; }
        public string article_code { get; set; }
        public string article_description { get; set; }
        public string ean { get; set; }
        public string hsn { get; set; }
        public int quantity { get; set; }
        public int qty_free { get; set; }
        public int uom { get; set; }
        public int case_size { get; set; }
        public decimal mrp { get; set; }
        public decimal base_price { get; set; }
        public string currency { get; set; }
        public decimal tax1_percent { get; set; }
        public decimal tax1_amount { get; set; }
        public decimal tax2_percent { get; set; }
        public decimal tax2_amount { get; set; }
        public decimal tax3_percent { get; set; }
        public decimal tax3_amount { get; set; }
        public decimal tax_amount { get; set; }
        public decimal item_total_amount { get; set; }
    }
}
