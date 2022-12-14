namespace CodecoolAdvanced.Model
{
    public class Log
    {
        public string email { get; set; }
        public string password { get; set; }
        public Log(string email, string password)
        {
            this.email = email;
            this.password = password;
        }   
    }
}
