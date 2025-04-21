using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class brandPerformanceRes
    {
        public string mvgr1 { get; set; }
        public string brand { get; set; }
        public decimal gross_sale { get; set; }
        public decimal net_amt { get; set; }
        public decimal target { get; set; }
        public decimal achv { get; set; }
    }
}
