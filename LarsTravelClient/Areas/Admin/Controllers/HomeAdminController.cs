using Microsoft.AspNetCore.Mvc;

namespace LarsTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class HomeAdminController : Controller
    {
        [HttpGet]
        [Route("Home")]
        public IActionResult Home()
        {
            return View();
        }
    }
}
