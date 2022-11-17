using CodecoolAdvanced.Model;
using Microsoft.AspNetCore.Mvc;

namespace CodecoolAdvanced.Controller
{
    [ApiController]
    [Route("api/Users")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<HashSet<User>> GetAllUsers() 
        {
            HashSet<User> users = UserCollector.Instance.GetAllUsers();
            return Ok(users);
        }
        [HttpGet]
        [Route("/{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            User user = UserCollector.Instance.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet]
        [Route("/actual")]
        public ActionResult<HashSet<Student>> GetActualStudents()
        {
            HashSet<Student> students = UserCollector.Instance.GetActualStudents();
            return Ok(students);
        }

        //[HttpPost]
        //[Route("/mentor")]
        //public ActionResult<Mentor> CreateNewMentor(string name, string email)
        //{
        //    Mentor mentor = new Mentor(name, email);
        //    UserCollector.Instance.AddUsersToCollector(mentor);
        //    return Ok(mentor);
        //}

        //[HttpPost]
        //[Route("/Student")]
        //public ActionResult<Student> CreateNewStudnet(string name, Branch branch, string email)
        //{
        //    Student student = new Student(name, branch, email);
        //    UserCollector.Instance.AddUsersToCollector(student);
        //    return Ok(student);
        //}

        [HttpDelete]
        [Route("/{id}")]
        public ActionResult DeleteUser(int id)
        {
            User user = UserCollector.Instance.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            UserCollector.Instance.RemoveFromStudents(user);
            return NoContent();
        }

        [HttpPut]
        [Route("/{id}")]
        public ActionResult ReNameUser(int id, string newName)
        {
            User user = UserCollector.Instance.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            user.Name = newName;
            return NoContent();

        }
    }
}
