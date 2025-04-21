using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.BusinessLogicLayer.Model
{
    public class salesHierarchyRes
    {
        public string id { get; set; }
        public string div { get; set; }
        public string zone { get; set; }
        public string fsCode { get; set; }
        public string name { get; set; }
        public string desg { get; set; }        
        public string scorecard { get; set; }
        public decimal net_amount { get; set; }
        public decimal target { get; set; }
        public decimal achv { get; set; }      
        public decimal var { get; set; }
        public decimal percRet { get; set; }
        public decimal v_lmtd { get; set; }
        public decimal v_lymtd { get; set; }
        public decimal v_lmtd1 { get; set; }
        public decimal v_lymtd1 { get; set; }
        public decimal lmgrowth { get; set; }
        public decimal growth { get; set; }

                   


    }
}
