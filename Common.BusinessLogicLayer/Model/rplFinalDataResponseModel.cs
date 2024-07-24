using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class rplFinalDataResponseModel
    {
        //ACriteria AMothly Q1 Q2  Q3 Q4  YTD TeamName    TeamURL Total_Score Top_Team
        public string ACriteria { get; set; }
        public string AMothly { get; set; }
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }
        public string Q4 { get; set; }
        public string YTD { get; set; }
        public string TeamName { get; set; }
        public string TeamURL { get; set; }
        public string Total_Score { get; set; }
        public string Top_Team { get; set; }


    }
}
