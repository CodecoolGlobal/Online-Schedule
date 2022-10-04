namespace InfluencerStudio.Models
{
    public class DefUser
    {
        private static DefUser instance = null;

        private DefUser()
        {
        }

        public static DefUser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DefUser();
                }
                return instance;
            }
        }

        static readonly string[] _accounts = { "Gmail, Youtube, Facebook, Instagram[apiusertest7@gmail.com, 777testuser]", "Twitter[fromGoogle]" };
        public string Token { get; } = "EAAIz88N8Bt4BALc20krZAhoQSJvbLIPqs4GbDwk4ZByZBUeXHywoZBkCDLhxZCvg4sZCZB2lG4xZBc8gZBYXt7PtZCEEwqEZBW6ro73xMuuC53sO4w835HuIxAmjyi7sMF70UXNRGerNZCoI8cdbR6O44an18IVHnOI1vnHRxM6QbePdGOQA9CZAVMAZCYDVuWUvG05Am83nEXvGKZAbARiHf2MUp19ULNT3dn3WWgXZCzIefMq6G802zLoZA93uifcYtg5GXYeAZD"; 
    }
}
