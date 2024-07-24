using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class rplModel
    {
        //exec PL_FillDRP @All=N'designation',@desigName=N'desi',@Empid=N'',@Role=N''
        public string all { get; set; }
        public string desigName { get; set; }
        public string empid { get; set; }
        public string role { get; set; }

    }
}
