namespace Login_API.Model
{
    public class _loginModel
    {
        public string emailid { get; set; }
        public string password { get; set; }
        public bool keepSignIn { get; set; } = false;
    }
}
