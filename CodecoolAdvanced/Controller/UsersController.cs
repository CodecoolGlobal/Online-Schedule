using CodecoolAdvanced.Model;
using CodecoolAvence.Model;
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
    }
}
