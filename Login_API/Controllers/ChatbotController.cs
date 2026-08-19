using Common.BusinessLogicLayer.IServices;
using Common.BusinessLogicLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace Login_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatbotController : Controller
    {
        
        private readonly IChatbotService _chatbot;

        public ChatbotController(IChatbotService chatbot) => _chatbot = chatbot;

        [HttpPost]
        [Route("generate")]
        public async Task<ActionResult<ResponseModel>> Generate(ChatbotReq req)
        {
            var a = await _chatbot.GenerateSqlAsync(req);
            return Ok(a);
        }

    }
}
