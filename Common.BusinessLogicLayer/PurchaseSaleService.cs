
using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Common.DataAccessLayer;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer
{
    public class PurchaseSaleService : IPurchaseSaleService
    {
        private readonly IDAL _dAL;
        public PurchaseSaleService(IDAL dAL)
        {
            _dAL = dAL;
        }
        public async Task<ResponseModel> getPurchaseSale(purchaseModel model)
        {
            try
            {

                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@invoice_number", model.invoice_number);
                queryParameters.Add("@grn_no", model.grn_no);
                queryParameters.Add("@order_date", model.order_date);
                queryParameters.Add("@delivery_date", model.delivery_date);
                queryParameters.Add("@expiry_date", model.expiry_date);
                queryParameters.Add("@order_type_value", model.order_type_value);
                queryParameters.Add("@supplier_id", model.supplier_id);
                queryParameters.Add("@supplier_name", model.supplier_name);
                queryParameters.Add("@supplier_ship_from_id", model.supplier_ship_from_id);
                queryParameters.Add("@supplier_ship_from_name", model.supplier_ship_from_name);
                queryParameters.Add("@supplier_ship_from_address1", model.supplier_ship_from_address1);
                queryParameters.Add("@supplier_ship_from_address2", model.supplier_ship_from_address2);
                queryParameters.Add("@supplier_ship_from_city", model.supplier_ship_from_city);
                queryParameters.Add("@supplier_ship_from_postal_code", model.supplier_ship_from_postal_code);
                queryParameters.Add("@supplier_ship_from_tax_id", model.supplier_ship_from_tax_id);
                queryParameters.Add("@supplier_bill_from_name", model.supplier_bill_from_name);
                queryParameters.Add("@supplier_bill_from_address1", model.supplier_bill_from_address1);
                queryParameters.Add("@supplier_bill_from_address2", model.supplier_bill_from_address2);
                queryParameters.Add("@supplier_bill_from_city", model.supplier_bill_from_city);
                queryParameters.Add("@supplier_bill_from_postal_code", model.supplier_bill_from_postal_code);
                queryParameters.Add("@supplier_bill_from_tax_id", model.supplier_bill_from_tax_id);
                queryParameters.Add("@buyer_ship_to_id", model.buyer_ship_to_id);
                queryParameters.Add("@buyer_ship_to_name", model.buyer_ship_to_name);
                queryParameters.Add("@buyer_ship_to_address1", model.buyer_ship_to_address1);
                queryParameters.Add("@buyer_ship_to_address2", model.buyer_ship_to_address2);
                queryParameters.Add("@buyer_ship_to_city", model.buyer_ship_to_city);
                queryParameters.Add("@buyer_ship_to_postal_code", model.buyer_ship_to_postal_code);
                queryParameters.Add("@buyer_ship_to_tax_id", model.buyer_ship_to_tax_id);
                queryParameters.Add("@buyer_sold_to_id", model.buyer_sold_to_id);
                queryParameters.Add("@buyer_sold_to_name", model.buyer_sold_to_name);
                queryParameters.Add("@buyer_sold_to_address1", model.buyer_sold_to_address1);
                queryParameters.Add("@buyer_sold_to_address2", model.buyer_sold_to_address2);
                queryParameters.Add("@buyer_sold_to_city", model.buyer_sold_to_city);
                queryParameters.Add("@buyer_sold_to_postal_code", model.buyer_sold_to_postal_code);
                queryParameters.Add("@buyer_sold_to_tax_id", model.buyer_sold_to_tax_id);
                queryParameters.Add("@total_tax1_amount", model.total_tax1_amount);
                queryParameters.Add("@total_tax2_amount", model.total_tax2_amount);
                queryParameters.Add("@total_tax3_amount", model.total_tax3_amount);
                queryParameters.Add("@discount_amount", model.discount_amount);
                queryParameters.Add("@scheme_discount_amount", model.scheme_discount_amount);
                queryParameters.Add("@adjustment_amount", model.adjustment_amount);
                queryParameters.Add("@cess_percent", model.cess_percent);
                queryParameters.Add("@cess_amount", model.cess_amount);
                queryParameters.Add("@total_amount", model.total_amount);
                queryParameters.Add("@currency", model.currency);
                queryParameters.Add("@company_name", model.company_name);
                // Convert invoice items to a DataTable
                var invoiceItemType = new DataTable();
                invoiceItemType.Columns.Add("InvoiceNumber", typeof(string));
                invoiceItemType.Columns.Add("ItemNo", typeof(int));
                invoiceItemType.Columns.Add("Batch", typeof(string));
                invoiceItemType.Columns.Add("ItemCategory", typeof(string));
                invoiceItemType.Columns.Add("ArticleCode", typeof(string));
                invoiceItemType.Columns.Add("ArticleDescription", typeof(string));
                invoiceItemType.Columns.Add("Ean", typeof(string));
                invoiceItemType.Columns.Add("Hsn", typeof(string));
                invoiceItemType.Columns.Add("Quantity", typeof(int));
                invoiceItemType.Columns.Add("QtyFree", typeof(int));
                invoiceItemType.Columns.Add("Uom", typeof(int));
                invoiceItemType.Columns.Add("CaseSize", typeof(int));
                invoiceItemType.Columns.Add("Mrp", typeof(decimal));
                invoiceItemType.Columns.Add("BasePrice", typeof(decimal));
                invoiceItemType.Columns.Add("Currency", typeof(string));
                invoiceItemType.Columns.Add("Tax1Percent", typeof(decimal));
                invoiceItemType.Columns.Add("Tax1Amount", typeof(decimal));
                invoiceItemType.Columns.Add("Tax2Percent", typeof(decimal));
                invoiceItemType.Columns.Add("Tax2Amount", typeof(decimal));
                invoiceItemType.Columns.Add("Tax3Percent", typeof(decimal));
                invoiceItemType.Columns.Add("Tax3Amount", typeof(decimal));
                invoiceItemType.Columns.Add("TaxAmount", typeof(decimal));
                invoiceItemType.Columns.Add("ItemTotalAmount", typeof(decimal));

                foreach (var item in model.invoice_items)
                {
                    invoiceItemType.Rows.Add(item.invoice_number, item.item_no, item.batch, item.item_category, item.article_code, item.article_description, item.ean, item.hsn, item.quantity, item.qty_free, item.uom, item.case_size, item.mrp, item.base_price, item.currency, item.tax1_percent, item.tax1_amount, item.tax2_percent, item.tax2_amount, item.tax3_percent, item.tax3_amount, item.tax_amount, item.item_total_amount);
                }

                queryParameters.Add("@invoice_items", invoiceItemType.AsTableValuedParameter("InvoiceItemType"));


                var response = await _dAL.GetIEnumerableData<rplDesignationModel>("sp_save_purchasesale_data", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "alk_common");

                return new ResponseModel
                {
                    Code = 1,
                    Data = response,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Code = 0,
                    Data = new ExceptionResponse { ErrorMessage = $"Error occured while fetching data : {ex.Message}" },
                    Message = $"Error : {ex.Message}"
                };
            }
            ResponseModel responseModel = new ResponseModel();

            return responseModel;
        }

        public async Task<ResponseModel> getSalesFields(sales_data_Model model)
        {
            try
            {

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@invoice_no", model.invoice_no);
                queryParameters.Add("@invoice_date", model.invoice_date);
                queryParameters.Add("@irn", model.irn);
                queryParameters.Add("@po_number", model.po_number);
                queryParameters.Add("@order_date", model.order_date);
                queryParameters.Add("@sales_order_no", model.sales_order_no);
                queryParameters.Add("@state", model.state);
                queryParameters.Add("@shipping_date", model.shipping_date);
                queryParameters.Add("@supply_area", model.supply_area);
                queryParameters.Add("@seller_id", model.seller_id);
                queryParameters.Add("@seller_name", model.seller_name);
                queryParameters.Add("@seller_address1", model.seller_address1);
                queryParameters.Add("@seller_address2", model.seller_address2);
                queryParameters.Add("@seller_city", model.seller_city);
                queryParameters.Add("@seller_postal_code", model.seller_postal_code);
                queryParameters.Add("@seller_tax_id", model.seller_tax_id);
                queryParameters.Add("@buyer_ship_to_id", model.buyer_ship_to_id);
                queryParameters.Add("@buyer_ship_to_name", model.buyer_ship_to_name);
                queryParameters.Add("@buyer_ship_to_address1", model.buyer_ship_to_address1);
                queryParameters.Add("@buyer_ship_to_address2", model.buyer_ship_to_address2);
                queryParameters.Add("@buyer_ship_to_city", model.buyer_ship_to_city);
                queryParameters.Add("@buyer_ship_to_postal_code", model.buyer_ship_to_postal_code);
                queryParameters.Add("@buyer_ship_to_tax_id", model.buyer_ship_to_tax_id);
                queryParameters.Add("@buyer_sold_to_id", model.buyer_sold_to_id);
                queryParameters.Add("@buyer_sold_to_name", model.buyer_sold_to_name);
                queryParameters.Add("@buyer_sold_to_address1", model.buyer_sold_to_address1);
                queryParameters.Add("@buyer_sold_to_address2", model.buyer_sold_to_address2);
                queryParameters.Add("@buyer_sold_to_city", model.buyer_sold_to_city);
                queryParameters.Add("@buyer_sold_to_postal_code", model.buyer_sold_to_postal_code);
                queryParameters.Add("@buyer_sold_to_tax_id", model.buyer_sold_to_tax_id);
                queryParameters.Add("@salesman_name", model.salesman_name);
                queryParameters.Add("@licence_no", model.licence_no);
                queryParameters.Add("@gross_taxable_amount", model.gross_taxable_amount);
                queryParameters.Add("@tax1_amount", model.tax1_amount);
                queryParameters.Add("@tax2_amount", model.tax2_amount);
                queryParameters.Add("@tax3_amount", model.tax3_amount);
                queryParameters.Add("@discount_amount", model.discount_amount);
                queryParameters.Add("@scheme_discount_amount", model.scheme_discount_amount);
                queryParameters.Add("@adjustment_amount", model.adjustment_amount);
                queryParameters.Add("@tcs_percent", model.tcs_percent);
                queryParameters.Add("@tcs_amount", model.tcs_amount);
                queryParameters.Add("@net_payable", model.net_payable);
                queryParameters.Add("@company_name", model.company_name);
                // Convert invoice items to a DataTable
                var items = new DataTable();
                items.Columns.Add("supplier_id", typeof(string));
                items.Columns.Add("supplier_name", typeof(string));
                items.Columns.Add("article_code", typeof(string));
                items.Columns.Add("article_description", typeof(string));
                items.Columns.Add("hsn", typeof(string));
                items.Columns.Add("ean", typeof(string));
                items.Columns.Add("batch", typeof(string));
                items.Columns.Add("qty", typeof(int));
                items.Columns.Add("qty_free", typeof(int));
                items.Columns.Add("uom", typeof(string));
                items.Columns.Add("seller_base_price", typeof(decimal));
                items.Columns.Add("mrp", typeof(decimal));
                items.Columns.Add("scheme_discount_amount", typeof(decimal));
                items.Columns.Add("tax1_percent", typeof(decimal));
                items.Columns.Add("tax1_amount", typeof(decimal));
                items.Columns.Add("tax2_percent", typeof(decimal));
                items.Columns.Add("tax2_amount", typeof(decimal));
                items.Columns.Add("tax3_percent", typeof(decimal));
                items.Columns.Add("tax3_amount", typeof(decimal));
                items.Columns.Add("tax_amount", typeof(decimal));
                items.Columns.Add("item_total_amount", typeof(decimal));
                items.Columns.Add("net_price", typeof(decimal));

                foreach (var item in model.items)
                {
                    items.Rows.Add(item.supplier_id,
                                     item.supplier_name,
                                     item.article_code,
                                     item.article_description,
                                     item.hsn,
                                     item.ean,
                                     item.batch,
                                     item.qty,
                                     item.qty_free,
                                     item.uom,
                                     item.seller_base_price,
                                     item.mrp,
                                     item.scheme_discount_amount,
                                     item.tax1_percent,
                                     item.tax1_amount,
                                     item.tax2_percent,
                                     item.tax2_amount,
                                     item.tax3_percent,
                                     item.tax3_amount,
                                     item.tax_amount,
                                     item.item_total_amount,
                                     item.net_price);
                }

                queryParameters.Add("@items", items.AsTableValuedParameter("sales_items_type"));


                var response = await _dAL.GetIEnumerableData<rplDesignationModel>("sp_save_sales_field_data", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "alk_common");

                return new ResponseModel
                {
                    Code = 1,
                    Data = response,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Code = 0,
                    Data = new ExceptionResponse { ErrorMessage = $"Error occured while fetching data : {ex.Message}" },
                    Message = $"Error : {ex.Message}"
                };
            }
            ResponseModel responseModel = new ResponseModel();

            return responseModel;
        }

        public async Task<ResponseModel> getStock(stockFieldModel stockFieldModel)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@customer_code", stockFieldModel.customer_code);
                queryParameters.Add("@customer_name", stockFieldModel.customer_name);
                queryParameters.Add("@customer_postal_code", stockFieldModel.customer_postal_code);
                queryParameters.Add("@customer_tax_id", stockFieldModel.customer_tax_id);

                queryParameters.Add("@supplier_id", stockFieldModel.supplier_id);
                queryParameters.Add("@article_code", stockFieldModel.article_code);
                queryParameters.Add("@article_description", stockFieldModel.article_description);
                queryParameters.Add("@batch", stockFieldModel.batch);

                queryParameters.Add("@mfg_date", stockFieldModel.mfg_date);
                queryParameters.Add("@expiry_date", stockFieldModel.expiry_date);
                queryParameters.Add("@qty", stockFieldModel.qty);
                queryParameters.Add("@uom", stockFieldModel.uom);

                queryParameters.Add("@mrp", stockFieldModel.mrp);
                queryParameters.Add("@dlp_pre_tax", stockFieldModel.dlp_pre_tax);
                queryParameters.Add("@dlp_post_tax", stockFieldModel.dlp_post_tax);
                queryParameters.Add("@rlp_pre_tax", stockFieldModel.rlp_pre_tax);
                queryParameters.Add("@rlp_post_tax", stockFieldModel.rlp_post_tax);
                queryParameters.Add("@company_name", stockFieldModel.company_name);
                var response = await _dAL.GetIEnumerableData<rplDesignationModel>("sp_stock_field_data", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "alk_common");

                return new ResponseModel
                {
                    Code = 1,
                    Data = response,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Code = 0,
                    Data = new ExceptionResponse { ErrorMessage = $"Error occured while fetching data : {ex.Message}" },
                    Message = $"Error : {ex.Message}"
                };
            }
            ResponseModel responseModel = new ResponseModel();

            return responseModel;
        }

        public async Task<ResponseModel> getToken(string userName, string password)
        {
            try
            {
                var status_code = 0;
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@userName", userName);
                queryParameters.Add("@password", password);
                 var response = await _dAL.GetIEnumerableData<TokenModel>("sp_check_token_val", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "alk_common");
                
                if(response.FirstOrDefault().Application_Name== userName && response.FirstOrDefault().Secret_Key== password)
                {
                    status_code = 1;
                }
                return new ResponseModel
                {
                    Code = status_code,
                    Data = response,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Code = 0,
                    Data = new ExceptionResponse { ErrorMessage = $"Error occured while fetching data : {ex.Message}" },
                    Message = $"Error : {ex.Message}"
                };
            }
            ResponseModel responseModel = new ResponseModel();

            return responseModel;
        }
    }
}
