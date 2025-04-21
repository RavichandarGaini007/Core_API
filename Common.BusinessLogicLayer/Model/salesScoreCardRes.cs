using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class salesScoreCardRes
    {
        public string Brand_Name { get; set; }
        public decimal Sale { get; set; }
        public decimal Target { get; set; }
        public decimal Ach { get; set; }
    }
}
