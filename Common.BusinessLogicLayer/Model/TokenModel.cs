using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class TokenModel
    {
        public int Application_ID { get; set; }
        public string Application_Name { get; set; }
        public string Secret_Key { get; set; }
        public string Issuer_Key { get; set; }
        public string Audience_Key { get; set; }
        public int Expire_Time { get; set; }
    }
}
