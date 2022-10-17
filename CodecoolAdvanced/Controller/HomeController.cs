using CodecoolAvence.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Helpers;

namespace CodecoolAdvanced.Controller
{
    [ApiController]
    [Route("api")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/actual/teams")]
        public string GetTeamsForActualWeek()
        {
            HashSet<Team> actualTeams = TeamCollector.Instance.GetCurrentWeekTeam();
            return Newtonsoft.Json.JsonConvert.SerializeObject(actualTeams); 
        }
    }
}
