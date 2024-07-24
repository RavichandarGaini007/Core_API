using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class salesModel
    {
        //@enetsale=N'''ALL''',@eplant=N'',@ehq=N'',@empcode=N'41406',@tgt_cop_flag=N''
        public string tbl_name { get; set; }
        public string enetsale { get; set; }
        public string eplant { get; set; }
        public string ehq { get; set; }
        public string empcode { get; set; }
        public string tgt_cop_flag { get; set; }
    }
}