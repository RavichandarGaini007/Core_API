using Common.BusinessLogicLayer.IServices;
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
                var response = await _idal.GetIEnumerableData<saleModel>("Proc_Sales_Portal_Dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database", 600);

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

                var response = await _idal.GetIEnumerableData<SalesMQYModel>("proc_sales_dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database", 600);

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

                var response = await _idal.GetIEnumerableData<salesAllDivWdgsRes>("proc_sales_allDiv_Dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database", 600);

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

                var response = await _idal.GetIEnumerableData<salesTopPerfmceRes>("proc_top_performance_dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database", 600);

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
                queryParameters.Add("@ename", req.ename);

                var response = await _idal.GetIEnumerableData<salesHierarchyRes>("proc_HierarchyWise_Dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database", 600);

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

                var response = await _idal.GetIEnumerableData<salesDivHqRes>("Proc_div_hq_data_Dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database", 600);

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
                queryParameters.Add("@hq", req.hq);

                var flatData = await _idal.GetIEnumerableData<salesScoreCardRes>("Proc_score_card_dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database", 600);

                var response = flatData
                .GroupBy(x => x.BrandRow)
                .Select(g =>
                {
                    var brandRow = g.First(x => x.ProdRows == 0);

                    return new salesScoreCardRes
                    {
                        Brand_Name = brandRow.Brand_Name,

                        Val_Sale = brandRow.Val_Sale,
                        Val_Target = brandRow.Val_Target,
                        Val_Ach = brandRow.Val_Ach,
                        Val_Lys = brandRow.Val_Lys,
                        Val_Growth = brandRow.Val_Growth,

                        Qty_Sale = brandRow.Qty_Sale,
                        Qty_Target = brandRow.Qty_Target,
                        Qty_Ach = brandRow.Qty_Ach,
                        Qty_Lys = brandRow.Qty_Lys,
                        Qty_Growth = brandRow.Qty_Growth,

                        products = g
                            .Where(x => x.ProdRows > 0)
                            .OrderBy(x => x.ProdRows)
                            .Select(p => new products
                            {
                                Product_Name = p.Brand_Name,

                                Val_Sale = p.Val_Sale,
                                Val_Target = p.Val_Target,
                                Val_Ach = p.Val_Ach,
                                Val_Lys = p.Val_Lys,
                                Val_Growth = p.Val_Growth,

                                Qty_Sale = p.Qty_Sale,
                                Qty_Target = p.Qty_Target,
                                Qty_Ach = p.Qty_Ach,
                                Qty_Lys = p.Qty_Lys,
                                Qty_Growth = p.Qty_Growth
                            })
                            .ToList()
                    };
                })
                .OrderBy(x => x.Brand_Name)
                .ToList();

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

                var response = await _idal.GetIEnumerableData<empAllDesgRes>("proc_get_emp_wise_desg", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database", 600);

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

                var response = await _idal.GetIEnumerableData<salesDivRes>("proc_fillDiv_dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database", 600);

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

                var response = await _idal.GetIEnumerableData<brandPerformanceRes>("proc_brand_performance_dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database", 600);

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
                queryParameters.Add("@ename", req.ename);

                var response = await _idal.GetIEnumerableData<sales_popup_Hqwiseres>("proc_Div_Hq_popSale_dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database", 600);

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
                queryParameters.Add("@ename", req.ename);

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
                queryParameters.Add("@ename", req.ename);

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
                queryParameters.Add("@ename", req.ename);

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

        public async Task<ResponseModel> getBrandCodeFromFlatFile(string div, string year, string screencode, string fieldname, string brandcode, string userid, string month)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", div);
                queryParameters.Add("@year", year);
                queryParameters.Add("@screencode", screencode);
                queryParameters.Add("@fieldname", fieldname);
                queryParameters.Add("@brandcode", brandcode);
                queryParameters.Add("@userid", userid);
                queryParameters.Add("@month", month);
                var response = await _idal.GetDynamicResult(
                     "GetDropDownList",
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

        public async Task<ResponseModel> GetDesGetDesgEmp(string division, string userid, string flag, string designation, string accesstype)
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

        public async Task<ResponseModel> NetworkWiseProductSale_S(salesComReqModel req)
        {
            try
            {
                string spname = req.type == "quarterwise" ? "NetworkWiseProductSale_Qtr_S" : "NetworkWiseProductSale_S";

                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", req.div);
                queryParameters.Add("@desg", req.desg);
                queryParameters.Add("@Misdesc", req.mis);
                queryParameters.Add("@plant", req.plant);
                queryParameters.Add("@brand", req.brand);
                queryParameters.Add("@product", req.product);
                queryParameters.Add("@month", req.month);
                queryParameters.Add("@year", req.year);


                var response = await _idal.GetDynamicResult(
                           spname,
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

        public async Task<ResponseModel> getSalesGroupDivData(salesComReqModel req)
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
                var response = await _idal.GetIEnumerableData<saleModel>("proc_groupDiv_Dashboard", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

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

        public async Task<ResponseModel> NetworkWiseProductYearlySale(salesComReqModel req)
        {
            try
            {
                var spName = "";
                DynamicParameters queryParameters = new DynamicParameters();

                if (req.type != "networkWiseProductWiseNepalYearly")
                {
                    queryParameters.Add("@Div", req.div);
                    queryParameters.Add("@desg", req.desg);
                    queryParameters.Add("@mis", req.mis);
                    queryParameters.Add("@plant", req.plant);
                    queryParameters.Add("@brand", req.brand);
                    queryParameters.Add("@product", req.product);
                    queryParameters.Add("@empCode", req.empcode);
                    queryParameters.Add("@Year", req.year);
                    queryParameters.Add("@month", req.month);

                    spName = "proc_NetworkWise_ProductYearly_Report_Dashboard";
                }
                else
                {
                    queryParameters.Add("@Div", req.div);
                    //queryParameters.Add("@finyear", GetFinancialYear(req.month, req.year));
                    queryParameters.Add("@finyear", req.year);
                    queryParameters.Add("@mis_Code", req.mis);

                    spName = "proc_get_nepal_network_wise_product_yearly";
                }
                var response = await _idal.GetDynamicResult(spName,
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

        public string GetFinancialYear(string strMonth, string strYear)
        {
            int month = Convert.ToInt32(strMonth);
            int year = Convert.ToInt32(strYear);

            if (month >= 4)
            {
                return year + "-" + (year + 1);
            }
            else
            {
                return (year - 1) + "-" + year;
            }
        }

        public async Task<ResponseModel> getHierarchyWiseValueWiseReport(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@div", req.div);
                queryParameters.Add("@desg", req.desg);
                queryParameters.Add("@month", req.month);
                queryParameters.Add("@year", req.year);
                queryParameters.Add("@empcode", req.empcode);
                var response = await _idal.GetIEnumerableData<RawData>("proc_get_network_value_emp_hierarchy", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters, conn_str: "sms_database");

                var service = new TreeService();
                var result = service.BuildTree((List<RawData>)response);

                return new ResponseModel
                {
                    Code = 1,
                    Data = result,
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

        public async Task<ResponseModel> custSalesTrendReport(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@f_month", req.f_month);
                queryParameters.Add("@f_year", req.f_year);
                queryParameters.Add("@t_month", req.month);
                queryParameters.Add("@t_year", req.year);
                queryParameters.Add("@strdiv", req.div);
                queryParameters.Add("@eplant", req.plant);
                queryParameters.Add("@ehq", req.hq);

                var response = await _idal.GetDynamicResult(
                           "proc_fill_customer_trend_report_dashboard",
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
            ResponseModel responseModel = new ResponseModel();

            return responseModel;
        }

        public async Task<ResponseModel> custSalesProductTrendReport(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@strFinYear", req.year);
                queryParameters.Add("@strdiv", req.div);
                queryParameters.Add("@strType", req.type);
                queryParameters.Add("@empcode", req.empcode);

                var response = await _idal.GetDynamicResult(
                           "proc_fill_customer_prod_trend_report_dashboard",
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
            ResponseModel responseModel = new ResponseModel();

            return responseModel;
        }

        public async Task<ResponseModel> corpPerformanceReport(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@type", req.type);
                queryParameters.Add("@month", req.month);
                queryParameters.Add("@year", req.year);

                var response = await _idal.GetDynamicResult(
                           "proc_performance_report_dashboard",
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
            ResponseModel responseModel = new ResponseModel();

            return responseModel;
        }

        public async Task<ResponseModel> GlanceReport(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@empCode", req.empcode);
                queryParameters.Add("@Div", req.div);
                queryParameters.Add("@desg", req.desg);
                queryParameters.Add("@mis", req.mis);
                queryParameters.Add("@Year", req.year);
                queryParameters.Add("@type", req.type);

                var response = await _idal.GetDynamicResult(
                           "proc_fill_glance_report_dashboard",
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
            ResponseModel responseModel = new ResponseModel();

            return responseModel;
        }

        public async Task<ResponseModel> DispensaryReport(salesComReqModel req)
        {
            try
            {
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@empCode", req.empcode);
                queryParameters.Add("@type", req.type);
                queryParameters.Add("@Div", req.div);
                queryParameters.Add("@brand", req.brand);
                queryParameters.Add("@product", req.product);
                queryParameters.Add("@Year", req.year);


                var response = await _idal.GetDynamicResult(
                           "proc_dispensary_report_dashboard",
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
            ResponseModel responseModel = new ResponseModel();

            return responseModel;
        }


    }
}
