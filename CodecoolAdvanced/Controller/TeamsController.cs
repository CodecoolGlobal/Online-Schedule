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
            Student student=UserCollector.Instance.GetStudentById(studentId);
            if (student == null)
            {
                return NotFound();
            }
            Team team = new Team(student, name);
            TeamCollector.Instance.AddTeam(team);
            return Ok(team);
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
            Student student = UserCollector.Instance.GetStudentById(studentid);
            if (team == null || student == null)
            {
                return NotFound();
            }
            team.AddStudent(student);
            return NoContent();
        }
        
        [HttpPut]
        [Route("{id}/remove/{studentid}")]
        public ActionResult RemoveStudentFromTeam(int id, int studentid)
        {
            Team team = TeamCollector.Instance.GetTeamById(id);
            Student student = UserCollector.Instance.GetStudentById(studentid);
            if (team == null || student == null)
            {
                return NotFound();
            }
            team.RemoveStudent(student);
            return NoContent();
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
