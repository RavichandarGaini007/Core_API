using Common.BusinessLogicLayer.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Common.BusinessLogicLayer.IServices
{
    
    public interface IChatbotService
    {
        Task<ResponseModel> GenerateSqlAsync(ChatbotReq req);
    }
}
