using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class checkEmpStatus
    {
        public string empcode { get; set; }
        public string status { get; set; }
    }
    public class empDetails
    {
        public string status { get; set; }
        public string div_name { get; set; }
        public string location { get; set; }
        public string department { get; set; }
        public string designation { get; set; }
        public string empname { get; set; }
        public string emailid { get; set; }
        public string mobileno { get; set; }
        public byte[] profileimage { get; set; }
        // Property to return the image as a Base64 URL string
        public string userprofile
        {
            get
            {
                if (profileimage != null && profileimage.Length > 0)
                {
                    // Convert the byte array to a Base64 string
                    string base64String = Convert.ToBase64String(profileimage);

                    // Return the Base64 string as a data URL (for displaying in an <img> tag)
                    return $"data:image/jpeg;base64,{base64String}"; // Adjust the MIME type if needed
                }

                // Return a default image if no image is found
                return "https://sales.alkemcrm.com/view_card/no-profile.jpg"; // Change to the path of a default image
            }
        }
    }
    public class brandCode
    {
        public string brand_code { get; set; }
        public string brand_name { get; set; }
    }
    public class brandDetails
    {
        public string brand_code { get; set; }
        public string brand_name { get; set; }
        public string product_name { get; set; }
        public string composition { get; set; }
    }
    public class details
    {
        public IEnumerable<empDetails> empDetails { get; set; }
        public IEnumerable<final_brand_details> brandDetails { get; set; }

    }
    public class final_brand_details
    {
        public string brand { get; set; }
        public List<list_products> products { get; set; }
    }
    public class list_products
    {
        public string product_name { get; set; }
        public string composition { get; set; }
    }
}
