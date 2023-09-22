using LarsTravelClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LarsTravelClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult CityTourDetail()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }
        
        public IActionResult History()
        {
            return View();
        }
        
        public IActionResult TourDetail()
        {
            return View();
        }

        public IActionResult AddTour()
        {
            return View();
        }

        public IActionResult AddCity()
        {
            return View();
        }

        public IActionResult AccountManager()
        {
            return View();
        }

        public IActionResult CityManager()
        {
            return View();
        }

        public IActionResult AddHotel()
        {
            return View();
        }

        public IActionResult HotelManager()
        {
            return View();
        }

        public IActionResult RevenueStatisticsDetail()
        {
            return View();
        }

        public IActionResult TourManager()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
