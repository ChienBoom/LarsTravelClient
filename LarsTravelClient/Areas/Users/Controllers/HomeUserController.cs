using Microsoft.AspNetCore.Mvc;

namespace LarsTravelClient.Areas.Users.Controllers
{
    [Area("Users")]
    public class HomeUserController : Controller
    {
        [HttpGet]
        [Route("/Home")]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet("/History")]
        public IActionResult History()
        {
            return View();
        }
    }
}
