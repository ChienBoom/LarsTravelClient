using Microsoft.AspNetCore.Mvc;

namespace LarsTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : Controller
    {
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }
    }
}
