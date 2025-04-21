using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class salesDivHqRes
    {
        public string msr { get; set; }
        public string vkbur { get; set; }
        public string bezei { get; set; }
        public decimal gross_sale { get; set; }
        public decimal net_amt1 { get; set; }
        public decimal target1 { get; set; }
        public decimal achv { get; set; }
        public string for_ord { get; set; }
    }
}
