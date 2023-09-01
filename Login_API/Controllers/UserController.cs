using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Login_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Login_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel>>  Register()
        {
          var a=await _userServices.User();
            return Ok(a);
        }
        
    }
}
