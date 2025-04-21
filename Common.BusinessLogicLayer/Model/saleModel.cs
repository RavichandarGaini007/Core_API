using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class saleModel
    {
        public string division { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value?.ToUpper(); }  // Convert to uppercase before setting
        }
        public decimal sale { get; set; }
        public decimal saleable { get; set; }
        public decimal nonsaleable { get; set; }
        public decimal diff { get; set; }
        public decimal netsales { get; set; }
        public decimal pend_pick { get; set; }
        public decimal total1 { get; set; }
        public decimal pend_ord { get; set; }
        public decimal total_ord1 { get; set; }
        public decimal unconf_ord1 { get; set; }
        public decimal net_amt { get; set; }
        public decimal target { get; set; }
        public decimal varv { get; set; }
        public decimal percRet { get; set; }
        public decimal lmtd { get; set; }
        public decimal lymtd { get; set; }
        public decimal lmtd1 { get; set; }
        public decimal lymtd1 { get; set; }
        public decimal tcamt { get; set; }
        public decimal mcamt { get; set; }
        public decimal ycamt { get; set; }
        public decimal toamt { get; set; }
        public decimal target_col { get; set; }
        public decimal unconf_ostd_ord { get; set; }
        public decimal unconf_total { get; set; }
        public decimal pend_disp { get; set; }
        public decimal unconf_stock { get; set; }
        public decimal growth_cy { get; set; }
        public decimal achv { get; set; }
        public decimal lmgrowth { get; set; }
        public decimal growth { get; set; }
        public string for_ord { get; set; }

    }
}
