using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class rplDesignationModel
    {
        public string DESG { get; set; }
    }
    public class rplrmcodeModel
    {
        public string rm_code { get; set; }
        public string rm_desc { get; set; }
        public string EmpCodeMISNAME { get; set; }
    }
    public class report_final_model
    {
        public string Division { get; set; }
        public string HQ { get; set; }
        public string hq_name { get; set; }
        public string rm_code { get; set; }
        public string rm_hq { get; set; }
        public string Criteria { get; set; }
        public string Monthly { get; set; }
        public string Quater1 { get; set; }
        public string Quater2 { get; set; }
        public string Quater3 { get; set; }
        public string Quater4 { get; set; }
        public string Yearly { get; set; }
    }
}
