using System.Xml.Linq;

namespace Login_API.Model
{
    public class userListModal
    {
        public int id { get; set; }
        public string code { get; set; }  
        public string Name {get; set; }
        public string Email { get;set; }    
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}
