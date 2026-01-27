using Common.BusinessLogicLayer;
using Common.BusinessLogicLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Common.BusinessLogicLayer.IServices;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.DataProtection.KeyManagement;


namespace Login_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonServices _comServices;
        private IConfiguration _config;

        public CommonController(ICommonServices comServices, IConfiguration config)
        {
            _comServices = comServices;
            _config = config;
        }

        [HttpPost]
        [Route("commonapi")]
        public async Task<ActionResult<string>> commonAPIMethod([FromQuery]  string apiUrl, [FromBody] object jsonBody = null)
        {
            ResponseModel responseModel = new ResponseModel();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = null;

                if ("" == "" && jsonBody != null)
                {
                    // Serialize the body as JSON
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(jsonBody), Encoding.UTF8, "application/json");
                    response = await client.PostAsync(apiUrl, jsonContent);
                }
                else
                {
                    // Handle other HTTP methods (e.g., GET) as before
                    response = await client.GetAsync(apiUrl);
                }

                response.EnsureSuccessStatusCode();
            }
            return  "";
        }

        [HttpPost]
        [Route("fgrnEntry")]
        public async Task<ActionResult<ResponseModel>> fgrnEntry(fgrnReqModel req)
        {
            if (!Request.Headers.TryGetValue("username", out var extractedusername))
            {
                return Unauthorized(new ResponseModel { Message = "username is missing" });
            }

            if (!Request.Headers.TryGetValue("password", out var extractedPass))
            {
                return Unauthorized(new ResponseModel { Message = "password is missing" });
            }

            //var apiKey = _config["Keys:ApiKey"];

            //var incomingHash = HashApiKey(extractedApiKey);

            //if(!CryptographicOperations.FixedTimeEquals(Convert.FromBase64String(incomingHash), Convert.FromBase64String(apiKey)))
            //{
            //    return Unauthorized(new ResponseModel { Message = "Invalid API Key" });
            //}

            var a = await _comServices.fgrnEntry(req, extractedusername, extractedPass);
            return Ok(a);
        }

        [HttpGet]
        public async Task<ActionResult<(string, string)>> GenerateApiKey()
        {
            var baseKey = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

            var hashedApiKey = HashApiKey(baseKey);
            return (baseKey, hashedApiKey);
        }

        public static string HashApiKey(string apiKey)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(apiKey);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
