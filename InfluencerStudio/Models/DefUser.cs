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
        public string Token { get; } = "EAAIz88N8Bt4BAG9OHM3sqiVSLCaVizXSCQgG4vf2UZCZBwi80DU2e6tY8AkkdW1BC1ogPYiq19QAcgBnm0HWxtUKvQF8n7HRAHLMfeZCAGRd7ZCnYtLSN3QSvppiNZC7ZCxh9zb7Tn7t96AEHELTlZBlnKr1mGmquyNMpadoGMNHZCvfo98Vo9hrZCnUrw9QYObZCcH3tjrvgSXG1jxXVmce9VFnZCgIcn9eaYrIZAaDJZAElhpiM4zeTzZBlAS2ZBfwuxg3CIZD"; 
    }
}
