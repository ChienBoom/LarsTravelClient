using Microsoft.AspNetCore.Mvc;

namespace LarsTravelClient.Areas.Users.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
