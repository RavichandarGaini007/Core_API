using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class ChatbotReq
    {
        public string tbl_name { get; set; }
        public string userQuestion { get; set; }
        public string? div { get; set; }
        public string? plant { get; set; }
        public string? hq { get; set; }
        
    }
}
