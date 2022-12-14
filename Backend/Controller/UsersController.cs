using CodecoolAdvanced.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodecoolAdvanced.Controller
{
    [ApiController]

    [Route("api/Users")]
    public class UsersController : ControllerBase
    {
        private readonly CodecoolContext _context;

        public UsersController(CodecoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("mentors")]
        public async Task<List<Mentor>> GetAllMentors()
        {
            return await _context.Mentors.ToListAsync();
        }
        [HttpGet]
        [Route("mentors/{id}")]
        public async Task<Mentor> GetMentorById(int id)
        {
            return await _context.GetMentor(id);
        }
        [HttpGet]
        [Route("student/{id}")]
        public async Task<Student> GetStudentById(int id)
        {
            return await _context.GetStudent(id);
        }
        [HttpGet]
        [Route("students")]
        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        [HttpPost]
        [Route("mentor")]
        public async Task<Mentor> CreateNewMentor(string name, string email)
        {
            Mentor mentor = new()
            {
                Name = name,
                Email = email
            };
            return await _context.AddMentor(mentor);
        }

        [HttpPost]
        [Route("student")]
        public async Task<Student> CreateNewStudnet(string name, Branch branch, string email)
        {
            Student student = new()
            {
                Name = name,
                SBranch = branch,
                Email = email
            };
            return await _context.AddStudent(student);
        }

        [HttpDelete]
        [Route("student/{id}")]
        public async Task DeleteStudentById(int id)
        {
            _context.DeleteStudent(id);
        }

        [HttpDelete]
        [Route("mentor/{id}")]
        public async Task DeleteMentrtById(int id)
        {
            _context.DeleteMentor(id);
        }

        [HttpPut]
        [Route("mentor/{id}")]
        public async Task ReNameMentor(int id, string newName)
        {
            _context.RenameMentor(id, newName);
        }
        [HttpPut]
        [Route("student/{id}")]
        public async Task ReNameStudent(int id, string newName)
        {
            _context.RenameStudent(id, newName);
        }
    }
}
