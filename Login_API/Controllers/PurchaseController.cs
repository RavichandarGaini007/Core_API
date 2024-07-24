using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Login_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseSaleService _purchaseSaleService;
        private readonly IConfiguration _config;
        public PurchaseController(IPurchaseSaleService purchaseSaleService,IConfiguration configuration) {
            _purchaseSaleService = purchaseSaleService;
            _config= configuration;
        }
        [HttpPost]
        [Route("GetPurchaseSale_API")]
        //[Authorize]
        public async Task<ActionResult<ResponseModel>> GetPurchaseSale(purchaseModel purchaseModel) 
        {
            var a = await _purchaseSaleService.getPurchaseSale(purchaseModel);
            return Ok(a);
        }
        [HttpPost]
        [Route("GetSales_API")]
        //[Authorize]
        public async Task<ActionResult<ResponseModel>> GetSalesFields(sales_data_Model _sales_data)
        {
            var a = await _purchaseSaleService.getSalesFields(_sales_data);
            return Ok(a);
        }
        [HttpPost]
        [Route("GetStock_API")]
        //[Authorize]
        public async Task<ActionResult<ResponseModel>> GetStockFields(stockFieldModel _stockField)
        {
            var a = await _purchaseSaleService.getStock(_stockField);
            return Ok(a);
        }
        [HttpPost]
        [Route("GetToken")]
        public string generateToken()
        {
            try
            {

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                  audience: _config["Jwt:Issuer"],
                  claims: null,
                  expires: DateTime.Now.AddMinutes(10),
                  signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                return token;
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
    }
}
