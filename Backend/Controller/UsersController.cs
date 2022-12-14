using CodecoolAdvanced.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CodecoolAdvanced.Controller
{
    [ApiController]
    [Route("api/users")]
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
        [Route("mentor/{id}")]
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
        public async Task<Mentor> PromoteToMentor(int id)
        {
            Student student = await _context.GetStudent(id);
            Mentor mentor = new()
            {
                Name = student.Name,
                Email = student.Email,
                Password = student.Password
            };
            await _context.DeleteStudent(student.ID);
            return await _context.AddMentor(mentor);
        }

        [HttpPost]
        [Route("student")]
        public async Task<Student> CreateNewStudnet(string name, string email, string password)
        {
            Student student = new()
            {
                Name = name,
                Email = email,
                Password = password
            };
            return await _context.AddStudent(student);
        }

        [HttpDelete]
        [Route("student/{id}")]
        public async Task DeleteStudentById(int id)
        {
            await _context.DeleteStudent(id);
        }

        [HttpDelete]
        [Route("mentor/{id}")]
        public async Task DeleteMentrtById(int id)
        {
            await _context.DeleteMentor(id);
        }

        [HttpPut]
        [Route("mentor/{id}")]
        public async Task ReNameMentor(int id, string newName)
        {
            await _context.RenameMentor(id, newName);
        }
        [HttpPut]
        [Route("student/{id}")]
        public async Task ReNameStudent(int id, string newName)
        {
            await _context.RenameStudent(id, newName);
        }

        [HttpPost]
        [Route("login")]
        public async Task<bool> Login(Log user)
        {
            string email = user.email;
            string password = user.password;
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                User User = await Task.FromResult(_context.Mentors.FirstOrDefault(user => user.Email == email && user.Password == password));
                string Role = "mentor";
                if (User == null)
                {
                    User = await Task.FromResult(_context.Students.FirstOrDefault(user => user.Email == email && user.Password == password));
                    Role = "student";
                    if(User == null)
                    {
                        return false;
                    }
                }
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, User.Email),
                    new Claim(ClaimTypes.Role, Role)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity)
                );
                return true;
            }
            return false;
        }
        [HttpPost]
        [Route("logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync();
        }
    }
}
