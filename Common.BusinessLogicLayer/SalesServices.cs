﻿using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Common.DataAccessLayer;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.BusinessLogicLayer
{
    internal class SalesServices : ISalesServices
    {
        private readonly IDAL _idal;
        public SalesServices(IDAL dAL)
        {
            _idal = dAL;
        }
        public async Task<ResponseModel> getSalesData(salesComReqModel req)
        {
            try
            {
                //@tbl_name = N'FTP_11_2024',@enetsale = N'ALL',@eplant = N'',@ehq = N'',@empcode = N'041406'
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@tbl_name", req.tbl_name);
                queryParameters.Add("@enetsale", req.div);
                queryParameters.Add("@eplant", req.plant);
                queryParameters.Add("@ehq", req.hq);
                queryParameters.Add("@empcode", req.empcode);
                var response = await _idal.GetIEnumerableData<saleModel>("Proc_Sales_Portal_Dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters,conn_str:"sms_database");

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

            //Task<IEnumerable<UserModel>> elist =  _idal.GetIEnumerableData<UserModel>("select * from Employee", CommandType.Text, dynamicParameters, 30);
            return responseModel;
        }

        public async Task<ResponseModel> getSalesAchvdata(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@tbl_name", req.tbl_name);
                queryParameters.Add("@empcode", req.empcode);
                queryParameters.Add("@div", req.div);
                queryParameters.Add("@month", req.month);
                queryParameters.Add("@year", req.year);
                queryParameters.Add("@flag", req.flag);

                var response = await _idal.GetIEnumerableData<SalesMQYModel>("proc_sales_dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

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
            
        }

        public async Task<ResponseModel> getSalesTblWidges(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@tbl_name", req.tbl_name);
                queryParameters.Add("@empcode", req.empcode);
                queryParameters.Add("@div", req.div);
                
                var response = await _idal.GetIEnumerableData<salesAllDivWdgsRes>("proc_sales_allDiv_Dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

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

        }

        public async Task<ResponseModel> getSalesTopPerformance(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@tbl_name", req.tbl_name);
                queryParameters.Add("@empcode", req.empcode);
                queryParameters.Add("@div", req.div);
                queryParameters.Add("@flag", req.flag);

                var response = await _idal.GetIEnumerableData<salesTopPerfmceRes>("proc_top_performance_dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

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

        }

        public async Task<ResponseModel> getSalesHierarchyDesg(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@tbl_name", req.tbl_name);
                queryParameters.Add("@empcode", req.empcode);
                queryParameters.Add("@div", req.div);
                queryParameters.Add("@month", req.month);
                queryParameters.Add("@year", req.year);
                queryParameters.Add("@desg", req.desg);

                var response = await _idal.GetIEnumerableData<salesHierarchyRes>("proc_HierarchyWise_Dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

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

        }

        public async Task<ResponseModel> getSalesDivHQ(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@tbl_name", req.tbl_name);
                queryParameters.Add("@empcode", req.empcode);
                queryParameters.Add("@div", req.div);
                queryParameters.Add("@month", req.month);
                queryParameters.Add("@year", req.year);

                var response = await _idal.GetIEnumerableData<salesDivHqRes>("Proc_div_hq_data_Dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

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

        }

        public async Task<ResponseModel> getSalesScData(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@tbl_name", req.tbl_name);
                queryParameters.Add("@empcode", req.empcode);
                queryParameters.Add("@div", req.div);
                queryParameters.Add("@month", req.month);
                queryParameters.Add("@year", req.year);

                var response = await _idal.GetIEnumerableData<salesScoreCardRes>("Proc_score_card_dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

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

        }

        public async Task<ResponseModel> getSalesEmpAllDesg(string EmpCode)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@empcode", EmpCode);

                var response = await _idal.GetIEnumerableData<empAllDesgRes>("proc_get_emp_wise_desg", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

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
        }

        public async Task<ResponseModel> getSalesDiv(string EmpCode)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@empcode", EmpCode);

                var response = await _idal.GetIEnumerableData<salesDivRes>("proc_fillDiv", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

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
        }

        public async Task<ResponseModel> getBrandPerfmnceData(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@tbl_name", req.tbl_name);
                queryParameters.Add("@empcode", req.empcode);
                queryParameters.Add("@div", req.div);

                var response = await _idal.GetIEnumerableData<brandPerformanceRes>("proc_brand_performance_dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

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

        }


        public async Task<ResponseModel> getDivHqReportData(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@tbl_name", req.tbl_name);
                queryParameters.Add("@empcode", req.empcode);
                queryParameters.Add("@div", req.div);
                queryParameters.Add("@month", req.month);
                queryParameters.Add("@year", req.year);
                queryParameters.Add("@plant", req.plant);
                queryParameters.Add("@hq", req.hq);
                queryParameters.Add("@region", req.region);
                queryParameters.Add("@mis", req.mis);

                var response = await _idal.GetIEnumerableData<sales_popup_Hqwiseres>("proc_Div_Hq_popSale_dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

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

        }

        public async Task<ResponseModel> getDivBrandReportData(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@tbl_name", req.tbl_name);
                queryParameters.Add("@empcode", req.empcode);
                queryParameters.Add("@div", req.div);
                queryParameters.Add("@month", req.month);
                queryParameters.Add("@year", req.year);
                queryParameters.Add("@mis", req.mis);

                var response = await _idal.GetIEnumerableData<sales_popup_brandwiseres>("proc_brand_popSale_dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

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

        }

        public async Task<ResponseModel> getDivPlantReportData(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@tbl_name", req.tbl_name);
                queryParameters.Add("@empcode", req.empcode);
                queryParameters.Add("@div", req.div);
                queryParameters.Add("@month", req.month);
                queryParameters.Add("@year", req.year);
                queryParameters.Add("@ename", req.ename);
                
                var response = await _idal.GetIEnumerableData<div_plantWiseReport_res>("proc_divPlantReport_sales_dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

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

        }

        public async Task<ResponseModel> getDivCustReportData(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@tbl_name", req.tbl_name);
                queryParameters.Add("@empcode", req.empcode);
                queryParameters.Add("@div", req.div);
                queryParameters.Add("@month", req.month);
                queryParameters.Add("@year", req.year);
                queryParameters.Add("@plant", req.plant);
                queryParameters.Add("@hq", req.hq);
                
                var response = await _idal.GetIEnumerableData<sales_custwiseReportRes>("proc_custReportSales_dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

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

        }

        public async Task<ResponseModel> getRegionReportData(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@tbl_name", req.tbl_name);
                queryParameters.Add("@empcode", req.empcode);
                queryParameters.Add("@div", req.div);
                queryParameters.Add("@brand", req.brand);

                var response = await _idal.GetIEnumerableData<sales_regionwiseRes>("proc_regionsalesreport_dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

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

        }

        public async Task<ResponseModel> getProductReportData(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@tbl_name", req.tbl_name);
                queryParameters.Add("@empcode", req.empcode);
                queryParameters.Add("@div", req.div);
                queryParameters.Add("@month", req.month);
                queryParameters.Add("@year", req.year);
                queryParameters.Add("@type", req.type);
                queryParameters.Add("@plant", req.plant);
                queryParameters.Add("@hq", req.hq);
                queryParameters.Add("@brand", req.brand);

                var response = await _idal.GetIEnumerableData<sales_prodwiseres>("proc_productreport_dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

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

        }

        public async Task<ResponseModel> LoginUser(string userName, string password)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@struname", userName);
                var response = await _idal.GetIEnumerableData<salesLoginModel>("Proc_sales_Dashboard_fillsession", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);
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
        }

        public async Task<ResponseModel> getMenu(string empCode, string role)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@empcode", empCode);
                queryParameters.Add("@role", role);
                var response = await _idal.GetIEnumerableData<salesMenuModel>("get_user_menu", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");
                var submenu = await _idal.GetIEnumerableData<salesMenuModel>("get_user_sub_menu", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

                var data = response.Select(d => new final_salesMenuModel
                {
                    name = d.name,
                    menu_icon = d.menu_icon,
                    url = d.url,
                    submenu = submenu.Where(s => s.menu_id == d.id).Select(s => new salesMenuModel
                    {
                        name = s.name,
                        menu_icon = s.menu_icon,
                        url = s.url
                    }).ToList()
                }).ToList();

                return new ResponseModel
                {
                    Code = 1,
                    Data = data,
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

            //Task<IEnumerable<UserModel>> elist =  _idal.GetIEnumerableData<UserModel>("select * from Employee", CommandType.Text, dynamicParameters, 30);
            return responseModel;
        }

        public async Task<ResponseModel> getBrandCodeFromFlatFile(string div, string year)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", div);
                queryParameters.Add("@year", year);
                var response = await _idal.GetIEnumerableData<BrandCodeFlatFile>("GetBrandCodeFromFlatFile", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "SAP_FGRN");

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
        }

        public async Task<ResponseModel> getFlatFilePrimarySales(string DownloadFor, string year, string empcode, string div, string brand_code)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@DownloadFor", DownloadFor);
                queryParameters.Add("@year", year);
                queryParameters.Add("@empcode", empcode);
                queryParameters.Add("@div", div);
                queryParameters.Add("@brandcode", brand_code);

                var response = await _idal.GetDynamicResult(
                           "GetFlatFileDataPrimarySales",
                           commandType: CommandType.StoredProcedure,
                           parameters: queryParameters,
                           conn_str: "SAP_FGRN"
                       );

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
        }

        public async Task<ResponseModel> getCustomize_tab_user(string userid)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@userid", userid);

                var response = await _idal.GetDynamicResult(
                           "Customize_tab_user_s",
                           commandType: CommandType.StoredProcedure,
                           parameters: queryParameters,
                           conn_str: "sms_database"
                       );

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
        }

        public async Task<ResponseModel> getFtpDetails(string name)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@name", name);

                var response = await _idal.GetDynamicResult(
                           "ftpdetails_s",
                           commandType: CommandType.StoredProcedure,
                           parameters: queryParameters,
                           conn_str: "sms_database"
                       );

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
        }

        public async Task<ResponseModel> GetDesGetDesgEmp(string division,string userid,string flag,string designation,string accesstype)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@ddldivision_value", division);
                queryParameters.Add("@empCode", userid);
                queryParameters.Add("@flag", flag);
                queryParameters.Add("@designation", designation);
                queryParameters.Add("@strAccessType", accesstype);


                var response = await _idal.GetDynamicResult(
                           "Proc_fill_Desg_Mis_Emp",
                           commandType: CommandType.StoredProcedure,
                           parameters: queryParameters,
                           conn_str: "sms_database"
                       );

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
        }

        public async Task<ResponseModel> NetworkWiseProductSale_S(string div)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", div);

                var response = await _idal.GetDynamicResult(
                           "NetworkWiseProductSale_S",
                           commandType: CommandType.StoredProcedure,
                           parameters: queryParameters,
                           conn_str: "sap_fgrn"
                       );

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
        }



    }
}
