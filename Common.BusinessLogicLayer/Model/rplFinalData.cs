using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class rplFinalData_get
    {
        public string designation { get; set; }
        public string empcode { get; set; }
        public string period { get; set; }
        public string selected_desg { get; set; }
        public string selected_empcode { get; set; }
    }
    public class rplFinalData
    {
        public string designation { get; set; }
        public string empcode { get; set; }
        public string period { get; set; }
    }
    public class rplmiscode
    {
        public string empcode { get; set; }
        public string division { get; set; }
        public string str_als { get; set; }
        public string designation { get; set; }
    }
    public class reportmodel
    {
        public string yearly { get; set; }
        public string quarter { get; set; }
    }
}
