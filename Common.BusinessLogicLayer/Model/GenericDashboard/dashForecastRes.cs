using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model.GenericDashboard
{
    public class dashForecastRes
    {
        public string DivCode { get; set; }
        public string DivName { get; set; }
        public string PlantCode { get; set; }
        public string PlantName { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int ShipperQty { get; set; }
        public string ProdCat { get; set; }
        public decimal Ptd { get; set; }
        public decimal Bsfcst { get; set; }
        public string BsfcstMsg { get; set; }
        public decimal Forecast { get; set; }
        public decimal Additional { get; set; }
        public decimal Additional2 { get; set; }
        public decimal TotalForecast { get; set; }
        public decimal Value { get; set; }
        public decimal CfaOpening { get; set; }
        public decimal WhIndent { get; set; }
        public decimal CfaExcessStock { get; set; }
        public decimal Punching { get; set; }
        public decimal StockAvailabilityAtCfa { get; set; }
        public int ACase { get; set; }
        public int CaseQty { get; set; }
        public decimal AddX { get; set; }
        public decimal ForcastX { get; set; }
        public string AddProdCat { get; set; }
        public decimal T1 { get; set; }
        public decimal T2 { get; set; }
        public bool Flag { get; set; }
    }
}
