using InfluencerStudio.Models;
using InfluencerStudio.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InfluencerStudio.Controller
{
    [Route("Api/facebook")]
    [ApiController]
    public class FacebookController : ControllerBase
    {
        private readonly FacebookService facebookService;

        public FacebookController(FacebookService facebookService)
        {
            this.facebookService = facebookService;
        }
        [HttpGet]
        //[Route("{actionToken}")]
        public string GetUserData()
        {
            Task<FacebookAccount> getAccountTask= facebookService.GetAccountAsync(DefUser.Instance.Token);
            Task.WaitAll(getAccountTask);
            FacebookAccount account = getAccountTask.Result;
            Console.WriteLine(account.Name);
            return JsonConvert.SerializeObject(account);
        }
    }
}
