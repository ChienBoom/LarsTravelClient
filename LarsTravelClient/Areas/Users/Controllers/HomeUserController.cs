using Microsoft.AspNetCore.Mvc;

namespace LarsTravelClient.Areas.Users.Controllers
{
    [Area("Users")]
    [Route("/user")]
    public class HomeUserController : Controller
    {
        [HttpGet]
        [Route("Home")]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet("History")]
        public IActionResult History()
        {
            return View();
        }
    }
}
