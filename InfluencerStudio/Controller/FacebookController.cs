using Microsoft.AspNetCore.Mvc;

namespace InfluencerStudio.Controller
{
    [Route]
    [ApiController]
    public class FacebookController : ControllerBase
    {
        [Route]
        public IActionResult Index()
        {
            return View();
        }
    }
}
