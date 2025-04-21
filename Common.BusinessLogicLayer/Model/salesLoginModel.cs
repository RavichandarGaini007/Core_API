using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.Model
{
    public class salesLoginModel
    {
        public string emp_code { get; set; }
        public string emailid { get; set; }
        public string sap_plant { get; set; }
        public string hq_id { get; set; }
        public string name { get; set; }
        public string enetsale { get; set; }
        public string userid { get; set; }
        public string role { get; set; }
        public string MISDESC { get; set; }
        public string desg { get; set; }
        public string group_id { get; set; }
        public string modelUrl { get; set; }
        public string modelUrlFlag { get; set; }
        public byte[] profileimage { get; set; }
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
}
