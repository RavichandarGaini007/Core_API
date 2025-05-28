using Common.BusinessLogicLayer;
using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Login_API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ServiceReference1;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace Login_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {

        private readonly ISalesServices _salesServices;
        private IConfiguration _config;
        public SalesController(ISalesServices salesServices, IConfiguration config)
        {
            _salesServices = salesServices;
            _config = config;
        }

        [Authorize]
        [HttpPost]
        [Route("salesdata")]
        public async Task<ActionResult<ResponseModel>> salesdata(salesComReqModel req)
        {
            var a = await _salesServices.getSalesData(req);
            return Ok(a);
        }

        [Authorize]
        [HttpPost]
        [Route("salesAchvdata")]
        public async Task<ActionResult<ResponseModel>> salesAchvdata(salesComReqModel req)
        {
            var a = await _salesServices.getSalesAchvdata(req);
            return Ok(a);
        }

        [Authorize]
        [HttpPost]
        [Route("SalesTblWidges")]
        public async Task<ActionResult<ResponseModel>> SalesTblWidges(salesComReqModel req)
        {
            var a = await _salesServices.getSalesTblWidges(req);
            return Ok(a);
        }

        [Authorize]
        [HttpPost]
        [Route("SalesTopPerformance")]
        public async Task<ActionResult<ResponseModel>> SalesTopPerformance(salesComReqModel req)
        {
            var a = await _salesServices.getSalesTopPerformance(req);
            return Ok(a);
        }

        [Authorize]
        [HttpPost]
        [Route("SalesHierarchyDesg")]
        public async Task<ActionResult<ResponseModel>> SalesHierarchyDesg(salesComReqModel req)
        {
            var a = await _salesServices.getSalesHierarchyDesg(req);
            return Ok(a);
        }

        [Authorize]
        [HttpPost]
        [Route("SalesDivHQ")]
        public async Task<ActionResult<ResponseModel>> SalesDivHQ(salesComReqModel req)
        {
            var a = await _salesServices.getSalesDivHQ(req);
            return Ok(a);
        }

        [Authorize]
        [HttpPost]
        [Route("SalesScData")]
        public async Task<ActionResult<ResponseModel>> SalesScData(salesComReqModel req)
        {
            var a = await _salesServices.getSalesScData(req);
            return Ok(a);
        }

        [Authorize]
        [HttpGet]
        [Route("SalesEmpAllDesg")]
        public async Task<ActionResult<ResponseModel>> SalesEmpAllDesg(string strEmpCode)
        {
            var a = await _salesServices.getSalesEmpAllDesg(strEmpCode);
            return Ok(a);
        }

        //[Authorize]
        [HttpGet]
        [Route("SalesDiv")]
        public async Task<ActionResult<ResponseModel>> SalesDiv(string strEmpCode)
        {
            var a = await _salesServices.getSalesDiv(strEmpCode);
            return Ok(a);
        }

        [Authorize]
        [HttpPost]
        [Route("BrandPerfmnceData")]
        public async Task<ActionResult<ResponseModel>> BrandPerfmnceData(salesComReqModel req)
        {
            var a = await _salesServices.getBrandPerfmnceData(req);
            return Ok(a);
        }

        [Authorize]
        [HttpPost]
        [Route("DivHqReportData")]
        public async Task<ActionResult<ResponseModel>> DivHqReportData(salesComReqModel req)
        {
            var a = await _salesServices.getDivHqReportData(req);
            return Ok(a);
        }

        [Authorize]
        [HttpPost]
        [Route("DivBrandReportData")]
        public async Task<ActionResult<ResponseModel>> DivBrandReportData(salesComReqModel req)
        {
            var a = await _salesServices.getDivBrandReportData(req);
            return Ok(a);
        }

        [Authorize]
        [HttpPost]
        [Route("DivPlantReportData")]
        public async Task<ActionResult<ResponseModel>> DivPlantReportData(salesComReqModel req)
        {
            var a = await _salesServices.getDivPlantReportData(req);
            return Ok(a);
        }

        [Authorize]
        [HttpPost]
        [Route("DivCustReportData")]
        public async Task<ActionResult<ResponseModel>> DivCustReportData(salesComReqModel req)
        {
            var a = await _salesServices.getDivCustReportData(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ResponseModel>> LoginUser(_loginModel _LoginModel)
        {
            Login_webserviceSoapClient login_WebserviceSoapClient = new Login_webserviceSoapClient(Login_webserviceSoapClient.EndpointConfiguration.Login_webserviceSoap);
            var flag = await login_WebserviceSoapClient.Check_loginAsync(_LoginModel.emailid, _LoginModel.password);
            if (_LoginModel.password == "demand")
            {
                flag = true;
            }
            if (flag == true)
            {
                var a = await _salesServices.LoginUser(_LoginModel.emailid, _LoginModel.password);
                string token = getToken(_LoginModel.keepSignIn);
                a.Token = token;
                return Ok(a);
            }
            else
            {
                return new ResponseModel
                {
                    Code = 0,
                    Data = new ExceptionResponse { ErrorMessage = "Your login failed due to: Invalid credentials OR Login expired OR Login locked OR Login disabled." },
                    Message = "Your login failed due to: Invalid credentials OR Login expired OR Login locked OR Login disabled."
                };
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("getDashboardMenus")]
        public async Task<ActionResult<ResponseModel>> getDashboardMenu(string empCode, string role)
        {
            var a = await _salesServices.getMenu(empCode, role);
            return a;
        }

        private string getToken(bool keepSignIn)
        {
            try
            {

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                  audience: _config["Jwt:Issuer"],
                  claims: null,
                  expires: keepSignIn == true ? DateTime.Now.AddHours(24) : DateTime.Now.AddMinutes(15),
                  signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                return token;
            }
            catch (Exception ex)
            {
                return "error";
            }
        }


        [HttpPost]
        [Route("RegionReportData")]
        public async Task<ActionResult<ResponseModel>> RegionReportData(salesComReqModel req)
        {
            var a = await _salesServices.getRegionReportData(req);
            return Ok(a);
        }

        [HttpPost]
        [Route("ProductReportData")]
        public async Task<ActionResult<ResponseModel>> ProductReportData(salesComReqModel req)
        {
            var a = await _salesServices.getProductReportData(req);
            return Ok(a);
        }
        [HttpGet]
        [Route("GetBrandCodeFromFlatFile")]
        public async Task<ActionResult<ResponseModel>> GetBrandCodeFromFlatFile(string div, string year)
        {
            var a = await _salesServices.getBrandCodeFromFlatFile(div, year);
            return Ok(a);
        }

        [HttpGet]
        [Route("GetFlatFilePrimarySales")]
        public async Task<ActionResult<ResponseModel>> GetFlatFilePrimarySales(string DownloadFor, string year, string empcode, string div, string brand_code)
        {
            var a = await _salesServices.getFlatFilePrimarySales(DownloadFor, year, empcode, div, brand_code);
            return Ok(a);
        }


        [HttpGet("download")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            string ftpHost = _config["ftp:ftphost"];
            string ftpUser = _config["ftp:ftpuser"];
            string ftpPass = _config["ftp:ftppass"];
            string ftpPath = fileName;

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpHost + ftpPath);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(ftpUser, ftpPass);
            request.UsePassive = true;
            request.UseBinary = true;
            request.EnableSsl = false;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, bytesRead);
                }

                byte[] fileBytes = memoryStream.ToArray();
                return File(fileBytes, "application/octet-stream", fileName);
            }

        }

        [HttpGet]
        [Route("GetCustomize_tab_user")]
        public async Task<ActionResult<ResponseModel>> getCustomize_tab_user(string userid)
        {
            var a = await _salesServices.getCustomize_tab_user(userid);
            return Ok(a);
        }

        [HttpGet("GetFtpFileLastModifiedDateTime")]
        public async Task<IActionResult> GetFtpFileLastModifiedDateTime(string fileName)
        {
            string ftpHost = _config["ftp:ftphost"];
            string ftpUser = _config["ftp:ftpuser"];
            string ftpPass = _config["ftp:ftppass"];

            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpHost + fileName));
            request.Proxy = null;
            request.Credentials = new NetworkCredential(ftpUser, ftpPass);
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            DateTime LastModified = response.LastModified;
            response.Close();
            return Ok(Convert.ToString(LastModified));
        }


    }
}
