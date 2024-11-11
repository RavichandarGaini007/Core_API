using Common.BusinessLogicLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Login_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        public CommonController()
        {

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
    }
}
