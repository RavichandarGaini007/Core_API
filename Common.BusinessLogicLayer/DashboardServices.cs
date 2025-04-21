using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Common.BusinessLogicLayer.Model.GenericDashboard;
using Common.DataAccessLayer;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.BusinessLogicLayer
{
    internal class DashboardServices : IDashboardServices
    {
        private readonly IDAL _idal;
        public DashboardServices(IDAL dAL)
        {
            _idal = dAL;
        }
        public async Task<ResponseModel> getForecast(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_desg", req.Desg);
                queryParameters.Add("@str_plant", req.Depot);
                queryParameters.Add("@str_month", req.Month);
                queryParameters.Add("@str_year", req.Year);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@str_role", req.role);
                queryParameters.Add("@str_type", req.flag);

                var response = await _idal.GetIEnumerableData<dashForecastRes>("Proc_gd_fill_demand_forcast_data_main_v1", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters,conn_str:"lottery");

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

        public async Task<ResponseModel> getForecast_DayWise(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_desg", req.Desg);
                queryParameters.Add("@str_plant", req.Depot);
                queryParameters.Add("@str_month", req.Month);
                queryParameters.Add("@str_year", req.Year);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@str_role", req.role);
                queryParameters.Add("@str_type", req.flag);
                queryParameters.Add("@type", req.Type);
                queryParameters.Add("@prod_code", req.Product);

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_demand_forcast_daywise", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getPmtGmForecastUpload(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_type", req.flag);
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_plant", req.Depot);
                queryParameters.Add("@str_product", req.Product);
                queryParameters.Add("@str_month", req.Month);
                queryParameters.Add("@str_year", req.Year);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@str_email_id", req.emailId);
                queryParameters.Add("@str_role", req.role);
                queryParameters.Add("@str_zkey", req.ZkeyFig);

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_demand_report_pviot", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getGmDepotTargetMaster(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_plant", req.Depot);
                queryParameters.Add("@str_f_year", req.FinYear);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@str_email_id", req.emailId);
                queryParameters.Add("@str_role", req.role);

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_depot_target_master", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getNetSaleReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_type", req.flag);
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_plant", req.Depot);
                queryParameters.Add("@str_year", req.Year);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@str_role", req.role);
                
                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_net_sale_report", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getAginReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_type", req.flag);
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_plant", req.Depot);
                queryParameters.Add("@str_month", req.Month);
                queryParameters.Add("@str_year", req.Year);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@str_email_id", req.emailId);               
                queryParameters.Add("@str_role", req.role);
                queryParameters.Add("@str_zkey", req.ZkeyFig);

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_agin_summary_report", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getMonthWiseForecastReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_desg", "");
                queryParameters.Add("@str_plant", req.Depot);
                queryParameters.Add("@str_month", req.Month);
                queryParameters.Add("@str_year", req.Year);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@str_role", req.role);

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_demand_forcast_data_final_report", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getForecastEntryStatusReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_desg", req.Desg);
                queryParameters.Add("@str_plant", req.Depot);
                queryParameters.Add("@str_month", req.Month);
                queryParameters.Add("@str_year", req.Year);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@str_role", req.role);
                queryParameters.Add("@str_type", req.flag);

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_demand_forcast_data_main_v1", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getForecastDesgReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_desg", req.Desg);
                queryParameters.Add("@str_plant", req.Depot);
                queryParameters.Add("@str_month", req.Month);
                queryParameters.Add("@str_year", req.Year);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@str_role", req.role);
                queryParameters.Add("@str_type", req.flag);

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_demand_forcast_report", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getFinalSaleForecastReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_desg", req.Desg);
                queryParameters.Add("@str_plant", req.Depot);
                queryParameters.Add("@str_month", req.Month);
                queryParameters.Add("@str_year", req.Year);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@str_role", req.role);
                queryParameters.Add("@str_type", req.flag);

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_demand_forcast_report_gm", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getFirstPriorityDispatchReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_desg", req.Desg);
                queryParameters.Add("@str_plant", req.Depot);
                queryParameters.Add("@str_month", req.Month);
                queryParameters.Add("@str_year", req.Year);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@str_role", req.role);
                queryParameters.Add("@str_type", req.flag);

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_First_Priority_Dispatch", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getCfaOpeningReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_month", req.Month);
                queryParameters.Add("@str_year", req.Year);
                queryParameters.Add("@flag", req.flag);

                var response = await _idal.GetIEnumerableData<saleModel>("proc_gd_opening_stock", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getBatchWiseReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@hdn_sesempid", req.empcode);
                queryParameters.Add("@ddldiv_val", req.Div);
                queryParameters.Add("@batchNo", req.Type);
                queryParameters.Add("@materialId", req.Product);

                var response = await _idal.GetIEnumerableData<saleModel>("proc_fill_batch_wise_Sale", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getCurrentWhStockReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_plant", req.Depot);
                queryParameters.Add("@str_product", req.Product);
                queryParameters.Add("@str_flag", req.flag);
                queryParameters.Add("@str_sh_life", req.Shelf_life);
                queryParameters.Add("@str_storage_loc", req.Storage_loc);
                
                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_agin_report", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getInventoryReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_plant", req.Depot);
                queryParameters.Add("@str_product", req.Product);
                queryParameters.Add("@str_month", req.Month);
                queryParameters.Add("@str_year", req.Year);
                queryParameters.Add("@str_flag", req.flag);
                queryParameters.Add("@stryear_type", req.strYear_type);
                queryParameters.Add("@sele_Days", req.sale_Days);

                string strSpName = "";

                if(req.Type == "ALL INDIA")
                {
                    strSpName = "Proc_gd_fill_inventory_report_dup_mis";
                }
                else if (req.Type == "WARE HOUSE")
                {
                    strSpName = "Proc_gd_fill_inventory_report_Warehouse_mis";
                }
                else
                {
                    strSpName = "Proc_gd_fill_inventory_report_mis";
                }

                var response = await _idal.GetIEnumerableData<saleModel>(strSpName, commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getAginMonthReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_plant", req.Depot);
                queryParameters.Add("@str_month", req.Month);
                queryParameters.Add("@str_year", req.Year);
                queryParameters.Add("@str_product", req.Product);
                queryParameters.Add("@str_flag", req.flag);

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_agin_report_month_wise", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getInventorySummeryReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_plant", req.Depot);

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_SUMMARY_Report", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getTargetPlanUploadData(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", req.Div);
                queryParameters.Add("@desg", req.Desg);
                queryParameters.Add("@depo", req.Depot);
                queryParameters.Add("@month", req.Month);
                queryParameters.Add("@year", req.Year);
                queryParameters.Add("@FLAG", "gd_fill_target_plan_upload_entry_data");
               
                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_target_plan_upload_entry_data", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getDivWiseReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", req.Div);
                queryParameters.Add("@month", req.Month);
                queryParameters.Add("@fin_year", req.FinYear);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@role", req.role);
                queryParameters.Add("@FLAG", "gd_fill_div_wise_sale_target");

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_report_div_wise_sale_target", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getDepotMasterSheetReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", req.Div);
                queryParameters.Add("@depo", req.Depot);
                queryParameters.Add("@fin_year", req.FinYear);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@role", req.role);
                queryParameters.Add("@FLAG", "gd_fill_party_wise_annual_target");

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_party_wise_annual_target", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getDepotWiseReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", req.Div);
                queryParameters.Add("@depo", req.Depot);
                queryParameters.Add("@month", req.Month);
                queryParameters.Add("@fin_year", req.FinYear);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@role", req.role);
                queryParameters.Add("@FLAG", "gd_fill_depot_wise_sale_target");

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_report_depot_wise_sale_target", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getSkuBrandWiseReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", req.Div);
                queryParameters.Add("@depo", req.Depot);
                queryParameters.Add("@month", req.Month);
                queryParameters.Add("@fin_year", req.FinYear);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@role", req.role);
                queryParameters.Add("@FLAG", "gd_fill_sku_brand_wise_sale_target");

                var response = await _idal.GetIEnumerableData<saleModel>("gd_report_sku_brand_wise_target", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getNewProductPerfmReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", req.Div);
                queryParameters.Add("@from_date", req.fromDt);
                queryParameters.Add("@to_date", req.toDt);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@role", req.role);
                queryParameters.Add("@FLAG", "fill_gd_report_new_prod");
                queryParameters.Add("@str_plant", req.Depot);

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_report_new_prod", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getCriticalOSReoport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div_id", req.Div);
                queryParameters.Add("@depot_id", req.Depot);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@role", req.role);
                queryParameters.Add("@FLAG", "SELECT_FTP_OUTSTANDING_REPORT");

                var response = await _idal.GetIEnumerableData<saleModel>("proc_outstanding_recovery_plan", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getHqWiseReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", req.Div);
                queryParameters.Add("@str_desg", req.Desg);
                queryParameters.Add("@depo", req.Depot);
                queryParameters.Add("@month", req.Month);
                queryParameters.Add("@fin_year", req.FinYear);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@role", req.role);
                queryParameters.Add("@FLAG", "gd_fill_hq_depot_wise_sale_target");

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_report_hq_depot_wise_sale_target", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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
        
        public async Task<ResponseModel> getHqSkuWiseReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", req.Div);
                queryParameters.Add("@month", req.Month);
                queryParameters.Add("@fin_year", req.FinYear);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@role", req.role);
                queryParameters.Add("@FLAG", "gd_fill_ho_wise_sku_performance");

                var response = await _idal.GetIEnumerableData<saleModel>("gd_ho_wise_sku_performance_report", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getHqBrandWiseReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", req.Div);
                queryParameters.Add("@depo", req.Depot);
                queryParameters.Add("@month", req.Month);
                queryParameters.Add("@fin_year", req.FinYear);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@role", req.role);
                queryParameters.Add("@FLAG", "gd_fill_ho_brand_performance_report");

                var response = await _idal.GetIEnumerableData<saleModel>("gd_ho_brand_performance_report", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getNearExpiryReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_div", req.Div);
                queryParameters.Add("@str_plant", req.Depot);
                queryParameters.Add("@str_month", req.Month);
                queryParameters.Add("@str_year", req.Year);
                queryParameters.Add("@str_product", req.Product);
                queryParameters.Add("@str_flag", req.flag);
               
                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_near_expiry_product", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getDivPerfmReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", req.Div);
                queryParameters.Add("@month", req.Month);
                queryParameters.Add("@fin_year", req.FinYear);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@role", req.role);
                queryParameters.Add("@FLAG", "gd_fill_div_performance");

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_report_ho_div_performance", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getSkuPerfmReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", req.Div);
                queryParameters.Add("@month", req.Month);
                queryParameters.Add("@fin_year", req.Year);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@role", req.role);
                queryParameters.Add("@FLAG", "gd_fill_ho_sku_performance");

                var response = await _idal.GetIEnumerableData<saleModel>("gd_report_ho_sku_performance", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getBrandPerfmReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", req.Div);
                queryParameters.Add("@month", req.Month);
                queryParameters.Add("@fin_year", req.FinYear);
                queryParameters.Add("@str_userid", req.empcode);
                queryParameters.Add("@role", req.role);
                queryParameters.Add("@FLAG", "gd_fill_ho_brand_performance");

                var response = await _idal.GetIEnumerableData<saleModel>("gd_report_ho_brand_performance", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getBulkMailReport(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@flag", req.flag);
                queryParameters.Add("@div", req.Div);
                queryParameters.Add("@month", req.Month);
                queryParameters.Add("@year", req.Year);
                queryParameters.Add("@jobId", req.JobId);
                
                var response = await _idal.GetIEnumerableData<saleModel>("proc_get_AutoMail_Report", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> updateNetSale(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_month", req.Month);
                queryParameters.Add("@str_year", req.Year);
                
                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_update_demand_sale_month", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getProductMaster(dash_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_month", req.Month);
                queryParameters.Add("@str_year", req.Year);

                var response = await _idal.GetIEnumerableData<saleModel>("Proc_gd_fill_product_master_view", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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




        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////// S.S Billing /////////////////////////////////////////
        
        public async Task<ResponseModel> getBillingOrderEntry(billing_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div_id", req.Div);
                queryParameters.Add("@plant_code", req.Depot);
                queryParameters.Add("@cust_email", req.cust_emailId);
                queryParameters.Add("@Flag", req.flag);
                queryParameters.Add("@OrderNo", req.orderNo);
                queryParameters.Add("@nk_role", req.role);
                queryParameters.Add("@user_Id", req.user_Id);
                queryParameters.Add("@pageFlag", req.pageFlag);

                var response = await _idal.GetIEnumerableData<billingOrderEntryRes>("proc_fill_order_entry", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getBillingInsOrderEntry(billing_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@tbl_name", req.Div);
                queryParameters.Add("@user_Id", req.user_Id);
                queryParameters.Add("@email_Id", req.cust_emailId);
                queryParameters.Add("@flag", req.flag);
                queryParameters.Add("@role", req.role);

                var response = await _idal.GetIEnumerableData<billingOrderEntryRes>("proc_ins_Order_entry", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getBillingOrderEntryMod(billing_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div_id", req.Div);
                queryParameters.Add("@plant_code", req.Depot);
                queryParameters.Add("@cust_email", req.cust_emailId);
                queryParameters.Add("@Flag", req.flag);
                queryParameters.Add("@OrderNo", req.orderNo);
                queryParameters.Add("@nk_role", req.role);
                queryParameters.Add("@user_Id", req.user_Id);
                queryParameters.Add("@pageFlag", req.pageFlag);

                var response = await _idal.GetIEnumerableData<billingOrderEntryModRes>("proc_fill_order_entry_grid", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getBillingOrderEntryModExcel(billing_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div_id", req.Div);
                queryParameters.Add("@plant_code", req.Depot);
                queryParameters.Add("@cust_email", req.cust_emailId);
                queryParameters.Add("@Order_No", req.orderNo);

                var response = await _idal.GetIEnumerableData<billingOrderEntryModExcel>("proc_fill_order_entry_modify_data", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getBillingApprovalOrder(billing_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div_id", req.Div);
                queryParameters.Add("@plant_code", req.Depot);
                queryParameters.Add("@cust_email", req.cust_emailId);
                queryParameters.Add("@Flag", req.flag);
                queryParameters.Add("@OrderNo", req.orderNo);
                queryParameters.Add("@role", req.role);
                queryParameters.Add("@user_Id", req.user_Id);
                queryParameters.Add("@status", req.status);

                var response = await _idal.GetIEnumerableData<billingOrderApprovalRes>("proc_fill_approval_order_grid", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getBillingApprovalOneOrder(billing_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@order_no", req.orderNo);
                queryParameters.Add("@emailId", req.cust_emailId);
                queryParameters.Add("@role", req.role);

                var response = await _idal.GetIEnumerableData<billingOrderApprovalRes>("proc_approval_whole_order", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getBillingProductApprovalOrder(billing_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@order_no", req.orderNo);
                queryParameters.Add("@emailId", req.cust_emailId);
                queryParameters.Add("@role", req.role);
                queryParameters.Add("@lblProductCode", req.product);
                queryParameters.Add("@OrderQty", req.OrderQty);                
                queryParameters.Add("@OrderUnits", req.OrderUnits);             
                queryParameters.Add("@OrderValue", req.OrderValue);
                queryParameters.Add("@OrderWeight", req.OrderWeight);
                queryParameters.Add("@strRemarks", req.strRemarks);
                queryParameters.Add("@strProdStatus", req.strProdStatus);
                queryParameters.Add("@pageFlag", req.pageFlag);
                queryParameters.Add("@txtProdRemarks", req.txtProdRemarks);

                var response = await _idal.GetIEnumerableData<billingOrderApprovalRes>("proc_approval_order_entry", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getBillingApprovedOrder(billing_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();

                queryParameters.Add("@div_id", req.Div);
                queryParameters.Add("@plant_code", req.Depot);
                queryParameters.Add("@cust_email", req.cust_emailId);
                queryParameters.Add("@Flag", req.flag);
                queryParameters.Add("@OrderNo", req.orderNo);
                queryParameters.Add("@role", req.role);
                queryParameters.Add("@user_Id", req.user_Id);
                queryParameters.Add("@status", req.status);

                var response = await _idal.GetIEnumerableData<billingApprovedOrderRes>("proc_fill_approved_orders", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getBillingPushToSapOrder(billing_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@OrderNo", req.orderNo);
                
                var response = await _idal.GetIEnumerableData<billingPushToSapRes>("proc_fill_SAP_orders", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getBillingSapOrderStatus(billing_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@order_no", req.orderNo);
                queryParameters.Add("@div_id", req.Div);
                queryParameters.Add("@plantId", req.Depot);
                queryParameters.Add("@MailStatus", req.mailStatus);
                queryParameters.Add("@sapStatus", req.sapStatus);
                queryParameters.Add("@user_Id", req.user_Id);

                var response = await _idal.GetIEnumerableData<billingApprovedOrderRes>("proc_ins_gd_order_email_sap_status", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getBillingOrderEntryReport(billing_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();

                queryParameters.Add("@div_id", req.Div);
                queryParameters.Add("@plant_code", req.Depot);
                queryParameters.Add("@cust_code", req.cust_id);
                queryParameters.Add("@OrderFromDt", req.OrderFrom);
                queryParameters.Add("@OrderToDt", req.OrderTo);
                queryParameters.Add("@flag", req.flag);
                queryParameters.Add("@status", req.status);
                queryParameters.Add("@product_code", req.product);
                queryParameters.Add("@role", req.role);
                queryParameters.Add("@emialId", req.cust_emailId);

                var response = await _idal.GetIEnumerableData<billingOrderReportRes>("proc_fill_order_entry_Report", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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

        public async Task<ResponseModel> getBillingPendingOrder(billing_comReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();

                queryParameters.Add("@div_id", req.Div);
                queryParameters.Add("@plant_code", req.Depot);
                queryParameters.Add("@cust_code", req.cust_id);
                queryParameters.Add("@month", req.month);
                queryParameters.Add("@year", req.year);
                queryParameters.Add("@nk_role", req.role);
                queryParameters.Add("@user_Id", req.user_Id);
                queryParameters.Add("@prod_code", req.product);
                queryParameters.Add("@emialId", req.cust_emailId);

                var response = await _idal.GetIEnumerableData<billingPendingOrderReportRes>("proc_nk_fill_pending_order_delvry_rpt", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "lottery");

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





    }
}
