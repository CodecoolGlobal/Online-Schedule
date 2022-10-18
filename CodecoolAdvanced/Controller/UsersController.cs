using Microsoft.AspNetCore.Mvc;

namespace CodecoolAdvanced.Controller
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
