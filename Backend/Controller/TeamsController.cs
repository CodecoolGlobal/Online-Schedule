using CodecoolAdvanced.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Helpers;

namespace CodecoolAdvanced.Controller
{
    [ApiController]
    
    [Route("api/teams")]
    public class TeamsController : ControllerBase
    {
        private readonly CodecoolContext _context;

        public TeamsController(CodecoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("actual")]
        public async Task<List<Team>> GetTeamsForActualWeek()
        {
            // I dont know what actual should return...
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("demos")]
        public async Task<List<Team>> GetDemos()
        {
            return await _context.GetDemos();
        }

        [HttpGet]
        public async Task<List<Team>> GetAllTeams()
        {

            return await _context.GetTeams();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Team> GetTeamById(int id)
        {
            return await _context.GetTeam(id);
        }
        [HttpGet]
        [Route("{id}/students")]
        public async Task<List<Student>> GetStudentsFromTeamById(int id)
        {
            return await _context.GetStudentsFromTeam(id);
        }

        [HttpPost]
        public async Task<Team> CreateNewTeam(int studentId, string name, string repo)
        {
            Student student = _context.Students.Include(s => s.SBranch).Where(s => s.ID == studentId).First();
            Team t = new()
            {
                Name = name,
                Students = new HashSet<Student>() {student},
                Progress = student.SBranch,
                Repo = repo,
                SiReviewStart = "0",
                SiReviewFinish = "0",
                TwReviewStart = "0",
                TwReviewFinish = "0",
                WeekChanged = 0,
                StartDate = DateTime.Now
            };
            return await _context.AddTeam(t);
        }
        
        [HttpPut]
        [Route("{id}")]
        public async Task RenameTeam(int id, string newName)
        {
            await _context.RenameTeamById(id, newName);
        }

        [HttpPut]
        [Route("{id}/review")]
        public async Task ChangeTimeOfReviewt(int id, string reviewTime, string type)
        {
            await _context.ChangeReviewTime(id, reviewTime, type);
        }

        [HttpPut]
        [Route("{id}/add/{studentid}")]
        public async Task AddStudentToTeam(int id, int studentid)
        {
            await _context.AddStudentToTeam(id, studentid);
        }
        
        [HttpPut]
        [Route("{id}/remove/{studentid}")]
        public async Task RemoveStudentFromTeam(int id, int studentid)
        {
            await _context.RemoveStudentFromTeam(id, studentid);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteTeam(int id)
        {
            await _context.DeleteTeam(id);
        }

        
    }
}
