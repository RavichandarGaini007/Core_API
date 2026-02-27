using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class salesScoreCardRes
    {
        public int BrandRow { get; set; }
        public int ProdRows { get; set; }
        public string Brand_Name { get; set; }
        public string Product_Name { get; set; }
        public decimal Val_Sale { get; set; }
        public decimal Val_Target { get; set; }
        public decimal Val_Ach { get; set; }
        public decimal Val_Lys { get; set; }
        public decimal Val_Growth { get; set; }
        public decimal Qty_Sale { get; set; }
        public decimal Qty_Target { get; set; }
        public decimal Qty_Ach { get; set; }
        public decimal Qty_Lys { get; set; }
        public decimal Qty_Growth { get; set; }
        public List<products> products { get; set; }
    }

    public class products
    {
        public string Product_Name { get; set; }
        public decimal Val_Sale { get; set; }
        public decimal Val_Target { get; set; }
        public decimal Val_Ach { get; set; }
        public decimal Val_Lys { get; set; }
        public decimal Val_Growth { get; set; }
        public decimal Qty_Sale { get; set; }
        public decimal Qty_Target { get; set; }
        public decimal Qty_Ach { get; set; }
        public decimal Qty_Lys { get; set; }
        public decimal Qty_Growth { get; set; }
    }
}
