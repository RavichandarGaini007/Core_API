using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class SalesMQYModel
    {

        public string division { get; set; }
        public string Div_Name { get; set; }
        public decimal netsales { get; set; }
        public decimal net_amt { get; set; }
        public decimal target { get; set; }
        public decimal achv { get; set; }
        public decimal growth_ly { get; set; }
        public decimal growth_lm { get; set; }
        public decimal saleable { get; set; }
        public decimal nonsaleable { get; set; }
        public decimal unconf_stock { get; set; }
        public decimal unconf_ostd_ord { get; set; }
    }            



}
