using CodecoolAdvanced.Model;
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
        public ActionResult<Team> CreateNewTeam(int studentId, string name)
        {
            User user=UserCollector.Instance.GetUserById(studentId);
            if (user == null)
            {
                return NotFound();
            }
            if (user is Student)
            {
                Team team = new Team((Student)user, name);
                TeamCollector.Instance.AddTeam(team);
                return Ok(team);
            }
            return NotFound();
        }
        
        [HttpPut]
        [Route("{id}")]
        public ActionResult RenameTeam(int id, string newName)
        {
            Team team = TeamCollector.Instance.GetTeamById(id);
            if (team == null)
            {
                return NotFound();
            }
            team.Name = newName;
            return NoContent();
        }
        
        [HttpPut]
        [Route("{id}/add/{studentid}")]
        public ActionResult AddStudentToTeam(int id, int studentid)
        {
            Team team = TeamCollector.Instance.GetTeamById(id);
            User user = UserCollector.Instance.GetUserById(studentid);
            if (team == null || user == null)
            {
                return NotFound();
            }
            if (user is Student)
            {
                team.AddStudent((Student)user);
                return NoContent();
            }
            return NotFound();
        }
        
        [HttpPut]
        [Route("{id}/remove/{studentid}")]
        public ActionResult RemoveStudentFromTeam(int id, int studentid)
        {
            Team team = TeamCollector.Instance.GetTeamById(id);
            User user = UserCollector.Instance.GetUserById(studentid);
            if (team == null || user == null)
            {
                return NotFound();
            }
            if (user is Student)
            {
                team.RemoveStudent((Student)user);
                return NoContent();
            }
            return NotFound();
        }
        
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteTeam(int id)
        {
            Team team = TeamCollector.Instance.GetTeamById(id);
            if (team == null)
            {
                return NotFound();
            }
            TeamCollector.Instance.DeleteTeam(team);
            return NoContent();
        }
    }
}
