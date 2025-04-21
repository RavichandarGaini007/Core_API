using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class salesMenuModel
    {
        public string name { get; set; }
        public string menu_icon { get; set; }
        public string url { get; set; }
        public string menu_id { get; set; }
        public string id { get; set; }
    }
    public class final_salesMenuModel
    {
        public string name { get; set; }
        public string menu_icon { get; set; }
        public string url { get; set; }
        public List<salesMenuModel> submenu { get; set; }
    }
}
