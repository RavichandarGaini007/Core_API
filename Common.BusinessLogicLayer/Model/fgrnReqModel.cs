using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class fgrnReqModel
    {
        [Required]
        public string plantCode { get; set; }
        public string? fgrn_doc { get; set; }
        [Required]
        public string partyCode { get; set; }
        [Required]
        public string plantName { get; set; }
        [Required]
        public DateTime? fgrn_date { get; set; }
        [Required]
        public string partyName { get; set; }
        [Required]
        public string partyPlace { get; set; }
        public string remarks { get; set; }
        [Required]
        public string transportName { get; set; }
        [Required]
        public DateTime? grn_date { get; set; }
        [Required]
        public string party_ref { get; set; }
        [Required]
        public DateTime? party_ref_date { get; set; }
        [Required]
        public string lr_num { get; set; }
        [Required]
        public DateTime? lr_date { get; set; }        
        public DateTime? entryDate { get; set; }
        //public bool? Flag { get; set; }
        [Required]
        public string? rateFlag { get; set; }
        [Required]
        public string refInv { get; set; }
        public string? taxFlag { get; set; }
        public string? tagId { get; set; }
        [Required]
        public int no_of_cases { get; set; }
        [Required]
        public string dcFile { get; set; }
        public string? instiFlag { get; set; }
        [Required]
        public string godownExp { get; set; }
        public string? nplHq { get; set; }
        [Required]
        public string vendorRefNo { get; set; }
        public List<productDetails> productDetails { get; set; }
    }

    public class productDetails
    {
        [Required]
        public string batch { get; set; }
        [Required]
        public string reason { get; set; }
        [Required]
        public string productCode { get; set; }
        [Required]
        public string productName { get; set; }
        [Required]
        public decimal? fgrnQty { get; set; }
        [Required]
        public decimal? fgrnSqty { get; set; }
        [Required]
        public decimal? fgrnMrp { get; set; }
    }
}
