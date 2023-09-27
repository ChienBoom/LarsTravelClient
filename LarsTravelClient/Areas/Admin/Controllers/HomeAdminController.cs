using LarsTravelClient.Commons;
using LarsTravelClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using LarsTravel.Models;

namespace LarsTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class HomeAdminController : Controller
    {
        private readonly CallApi _callApi;

        public HomeAdminController(CallApi callApi)
        {
            _callApi = callApi;
        }

        [HttpGet]
        [Route("Home")]
        public async Task<IActionResult> Home()
        {
            string urlCity = "https://localhost:44348/api/City";
            string urlTour = "https://localhost:44348/api/Tour";
            try
            {
                ResponseData responseDataCity = await _callApi.GetApi(urlCity);
                ResponseData responseDataTour = await _callApi.GetApi(urlTour);
                if (responseDataCity.Success && responseDataTour.Success)
                {
                    if (responseDataCity.Message.Equals("Success") && responseDataTour.Message.Equals("Success"))
                    {
                        ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseDataCity.ResultData);
                        ViewData["Tours"] = JsonConvert.DeserializeObject<List<Tour>>(responseDataTour.ResultData);
                        return View();
                    }
                    return RedirectToAction("Error", "HomeAdmin");
                }
                return RedirectToAction("Error", "HomeAdmin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "HomeAdmin");
            }
        }
    }
}
