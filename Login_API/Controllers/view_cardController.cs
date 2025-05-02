using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Login_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class view_cardController : ControllerBase
    {
        private readonly IViewCardService _viewCardService;
        public view_cardController(IViewCardService viewCardService)
        {
            _viewCardService=viewCardService;
        }
        [HttpPost]
        [Route("view_card")]
        public async Task<ActionResult<string>> checkEmployeeStatus(string empcode)
        {
            var a = await _viewCardService.check_EmpStatus(empcode);
            // Redirect the user to the URL with parameters
            string url = "https://sales.alkemcrm.com/view_card/";
            return RedirectPermanent(url);
        }
        [HttpPost]
        [Route("getempdetails")]
        public async Task<ActionResult<ResponseModel>> getEmployeeDetails(string empcode)
        {
            var a = await _viewCardService.employee_Details(empcode);

            return a;
        }
        [HttpPost]
        [Route("getbranddetails")]
        public async Task<ActionResult<ResponseModel>> getBrandDetails(string empcode)
        {
            var a = await _viewCardService.brand_details(empcode);

            return a;
        }

        [HttpPost]
        [Route("getGenericBrand")]
        public async Task<ActionResult<ResponseModel>> generic_brand_Details()
        {
            var a = await _viewCardService.generic_brand_Details();

            return a;
        }

        [HttpGet]
        [Route("getinvoicepdf")]
        public async Task<ActionResult<ResponseModel>> Get_Invoice_Pdf(string invoiceno)
        {
            var a = await _viewCardService.Get_Invoice_Pdf(invoiceno);

            return a;
        }
    }
}
