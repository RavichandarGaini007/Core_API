using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Common.DataAccessLayer;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer
{
    internal class RPLServices : IRPLServices
    {
        private readonly IDAL _idal;
        public RPLServices(IDAL dAL)
        {
            _idal = dAL;
        }
        public async Task<ResponseModel> getMasterData(rplModel rplModel)
        {
            try
            {

                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@All", rplModel.all);
                queryParameters.Add("@desigName", rplModel.desigName);
                queryParameters.Add("@Empid", rplModel.empid);
                queryParameters.Add("@Role", rplModel.role);
                var response = await _idal.GetIEnumerableData<rplDesignationModel>("PL_FillDRP", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);

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
        public async Task<ResponseModel> getDesigEmpMasterData(rplModel rplModel)
        {
            try
            {

                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@All", rplModel.all);
                queryParameters.Add("@desigName", rplModel.desigName);
                queryParameters.Add("@Empid", rplModel.empid);
                queryParameters.Add("@Role", rplModel.role);
                var response = await _idal.GetIEnumerableData<rplEmployeeModel>("PL_FillDRP", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);

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

        public async Task<ResponseModel> getfinalrpldata(rplFinalData_get rplFinalData)
        {
            try
            {
                string _month="", _year="",_year1 = "";
                string YearN = GetCurrentFinancialYear();

                if (rplFinalData.period == "QTR-1")
                {
                    _year = (YearN.Split('-')[0]).ToString();
                    _month = DateTime.Now.Month.ToString();
                }
                else if (rplFinalData.period == "QTR-2")
                {
                    _year = (YearN.Split('-')[0]).ToString();
                    _month = DateTime.Now.Month.ToString();
                }
                else if (rplFinalData.period == "QTR-3")
                {
                    _year = (YearN.Split('-')[0]).ToString();
                    _month = DateTime.Now.Month.ToString();
                }
                else if (rplFinalData.period == "QTR-4")
                {
                    _year = (YearN.Split('-')[1]).ToString();
                    _month = DateTime.Now.Month.ToString();
                }
               else if (rplFinalData.period.Contains("Jan") || rplFinalData.period.Contains("Feb") || rplFinalData.period.Contains("Mar") || rplFinalData.period.Contains("Apr") || rplFinalData.period.Contains("May") || rplFinalData.period.Contains("Jun") || rplFinalData.period.Contains("Jul") || rplFinalData.period.Contains("Aug") || rplFinalData.period.Contains("Sep") || rplFinalData.period.Contains("Oct") || rplFinalData.period.Contains("Nov") || rplFinalData.period.Contains("Dec"))
                {
                    string _m = rplFinalData.period.Split("-")[0];
                    int _m2 = GetMonthNumber(_m);
                    _month = _m2.ToString();
                    _year= rplFinalData.period.Split("-")[1];
                }
                else
                {
                    _year = rplFinalData.period.Split("-")[0];
                    _year1= rplFinalData.period.Split("-")[1];
                    _month = DateTime.Now.Month.ToString();
                }

                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@Designation", rplFinalData.designation);
                queryParameters.Add("@EmpCode", rplFinalData.empcode);
                queryParameters.Add("@Month", _month);
                queryParameters.Add("@Year", _year);
                queryParameters.Add("@Year1", _year1);
                queryParameters.Add("@Period", rplFinalData.period);
                queryParameters.Add("@sel_desg", rplFinalData.selected_desg);
                queryParameters.Add("@sel_empcode", rplFinalData.selected_empcode);
                var response = await _idal.GetIEnumerableData<rplFinalDataResponseModel>("RPL_GetDesiNamewiedataNew_RM_Main", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);

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
        public static string GetCurrentFinancialYear()
        {
            int CurrentYear = DateTime.Today.Year;
            int PreviousYear = DateTime.Today.Year - 1;
            int NextYear = DateTime.Today.Year + 1;
            string PreYear = PreviousYear.ToString();
            string NexYear = NextYear.ToString();
            string CurYear = CurrentYear.ToString();
            string FinYear = null;

            if (DateTime.Today.Month > 3)
                FinYear = CurYear + "-" + NexYear;
            else
                FinYear = PreYear + "-" + CurYear;
            return FinYear.Trim();
        }
        public static int GetMonthNumber(string monthName)
        {
            try
            {
                // Parse the month name using DateTime.ParseExact method
                DateTime date = DateTime.ParseExact(monthName, "MMM", System.Globalization.CultureInfo.InvariantCulture);

                // Get the month number from the parsed date
                int monthNumber = date.Month;

                return monthNumber;
            }
            catch (FormatException)
            {
                // Handle format exception (invalid month name)
                Console.WriteLine($"Invalid month name: {monthName}");
                return -1; // or throw exception
            }
        }

        public async Task<ResponseModel> getrmcodedata(rplFinalData rplFinalData)
        {
            try
            {

                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@code", rplFinalData.designation);
                queryParameters.Add("@value", rplFinalData.empcode);
                var response = await _idal.GetIEnumerableData<rplrmcodeModel>("get_rmcode_rmdesc", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);

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

        public async Task<ResponseModel> getrplmiscode(rplmiscode rplFinalData)
        {
            try
            {

                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@str_emp", rplFinalData.empcode);
                queryParameters.Add("@str_sale_div", rplFinalData.division);
                queryParameters.Add("@str_als", rplFinalData.str_als);
                queryParameters.Add("@str_flag", rplFinalData.designation);
                var response = await _idal.GetIEnumerableData<rplrmcodeModel>("PL_Get_Code_Hq", commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);
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
        public async Task<ResponseModel> getreportdata(reportmodel reportmodel)
        {
            try
            {
                //exec[RPL_GetDesiNamewiedataNew_Qumulative_Report_RM] @Designation = N'ME',@EmpCode = N'',@Month = 0,@Year = N'2023',@Year1 = N'2024'

                //exec PL_GetDesiNamewiedataNew_QTR_Report @Designation = N'ME',@EmpCode = N'',@Month = 0,@Year = N'2024',@Year1 = N'2025',@QTR = N'QTR-1'
                string[] _year = reportmodel.yearly.Split('-');
                string sp_name = "";
                DynamicParameters queryParameters = new DynamicParameters();
                queryParameters.Add("@Designation", "ME");
                queryParameters.Add("@EmpCode", "");
                queryParameters.Add("@Month", 0);
                queryParameters.Add("@Year", _year[0]);
                queryParameters.Add("@Year1", _year[1]);
                if (reportmodel.quarter== "Yearly")
                {
                    sp_name = "RPL_GetDesiNamewiedataNew_Qumulative_Report_RM";
                }
                else
                {
                    queryParameters.Add("@QTR", reportmodel.quarter);
                    sp_name = "RPL_GetDesiNamewiedataNew_QTR_Report_RM";
                }
               
            
                var response = await _idal.GetIEnumerableData<report_final_model>(sp_name, commandType: System.Data.CommandType.StoredProcedure, parameters: queryParameters);
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
    }
}
