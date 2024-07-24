using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class userlistmodel
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string role { get; set; }
    }
    public class addnewuser
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string role { get; set; }
    }
}
