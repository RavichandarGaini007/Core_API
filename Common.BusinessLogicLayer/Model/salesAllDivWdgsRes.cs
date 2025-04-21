using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.BusinessLogicLayer.Model
{
    public class salesAllDivWdgsRes
    {
        public string name { get; set; }
        public decimal net_amt { get; set; }
        public decimal target { get; set; }
        public decimal achv { get; set; }

    }
}
