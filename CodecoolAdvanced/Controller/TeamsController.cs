using CodecoolAvence.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Helpers;

namespace CodecoolAdvanced.Controller
{
    [ApiController]
    [Route("api/teams")]
    public class TeamsController : ControllerBase
    {
        [HttpGet]
        [Route("actual")]
        public ActionResult<HashSet<Team>> GetTeamsForActualWeek()
        {
            HashSet<Team> actualTeams = TeamCollector.Instance.GetCurrentWeekTeam();
            return Ok(actualTeams); 
        }
        [HttpGet]
        public ActionResult<HashSet<Team>> GetAllTeams()
        {
            HashSet<Team> allteams = TeamCollector.Instance.GetTeams();
            return Ok(allteams);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Team> GetTeamById(int id)
        {
            Team team = TeamCollector.Instance.GetTeamById(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [HttpPost]
        public ActionResult<Team> CreateNewTeam(Student student, string name)
        {
            Team team = new Team(student, name);
            TeamCollector.Instance.AddTeam(team);
            return Ok(team);
        }
    }
}
