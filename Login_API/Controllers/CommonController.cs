using Common.BusinessLogicLayer;
using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Login_API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;


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

        private string GenerateAccessToken(string userId)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim("type", "access")
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("gentoken")]
        public IActionResult Refresh([FromHeader(Name = "X-API-ID")] string apiId, [FromHeader(Name = "X-API-PASSWORD")] string apiPassword)
        {
            var configuredApiId = _config["ApiCredentials:ApiId"];
            var configuredApiPassword = _config["ApiCredentials:ApiPassword"];

            if (apiId != configuredApiId || apiPassword != configuredApiPassword)
            {
                return Unauthorized("Invalid API ID or Password");
            }

            var token = GenerateAccessToken("00160151");

            return Ok(new { accessToken = token });
        }

        //[Authorize]
        [HttpGet]
        [Route("empPendAckCount")]
        public async Task<ActionResult<ResponseModel>> empPendAckCount()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                return Unauthorized();

            var accessToken = authHeader["Bearer ".Length..].Trim();

            var handler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal;

            try
            {
                principal = handler.ValidateToken(
                    accessToken,
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidIssuer = _config["Jwt:Issuer"],
                        ValidAudience = _config["Jwt:Audience"], // separate config key
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
                        ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256 },
                        ClockSkew = TimeSpan.FromSeconds(150) // tighten default 5-min skew if desired
                    },
                    out _
                );
            }
            catch (SecurityTokenException)
            {
                return Unauthorized();
            }
            catch (ArgumentException)
            {
                return Unauthorized();
            }

            // Require an ACCESS token here, not a refresh token
            var tokenType = principal.FindFirst("type")?.Value;
            if (tokenType != "access")
                return Unauthorized();

            var a = await _comServices.empPendAckCount();

            return Ok(a);
        }


        [HttpGet]
        [Route("empCompAckCount")]
        public async Task<ActionResult<ResponseModel>> empCompAckCount()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                return Unauthorized();

            var accessToken = authHeader["Bearer ".Length..].Trim();

            var handler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal;

            try
            {
                principal = handler.ValidateToken(
                    accessToken,
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidIssuer = _config["Jwt:Issuer"],
                        ValidAudience = _config["Jwt:Audience"], // separate config key
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
                        ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256 },
                        ClockSkew = TimeSpan.FromSeconds(150) // tighten default 5-min skew if desired
                    },
                    out _
                );
            }
            catch (SecurityTokenException)
            {
                return Unauthorized();
            }
            catch (ArgumentException)
            {
                return Unauthorized();
            }

            // Require an ACCESS token here, not a refresh token
            var tokenType = principal.FindFirst("type")?.Value;
            if (tokenType != "access")
                return Unauthorized();

            var a = await _comServices.empCompAckCount();

            return Ok(a);
        }
    }
}
