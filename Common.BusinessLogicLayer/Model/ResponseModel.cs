using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class ResponseModel
    {
        public int Code { get; set; }

        public object Data { get; set; }

        public string Message { get; set; } = "Success";
        public string Token { get; set; }
        public string EmailKeyEncrypted { get; set; }
        public string UserKeyEncrypted { get; set; }
        public string EmailEncryptionString { get; set; }
    }
}
