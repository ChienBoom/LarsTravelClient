using LarsTravel.Models;
using LarsTravelClient.Commons;
using LarsTravelClient.Models;
using LarsTravelClient.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LarsTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class CityAdminController : Controller
    {
        private CallApi _callApi;
        public CityAdminController(CallApi callApi)
        {
            _callApi = callApi;
        }

        [HttpGet]
        [Route("CityTourDetail")]
        public IActionResult CityTourDetail()
        {
            string stringCity = TempData["CityTourDetail"].ToString();
            City city = JsonConvert.DeserializeObject<City>(stringCity);
            if (city != null)
            {
                ViewData["CityTourDetail"] = city;
                return View();
            }
            return RedirectToAction("Error", "HomeAdmin");
        }

        [HttpGet]
        [Route("CityManager")]
        public IActionResult CityManager()
        {
            return View();
        }

        [HttpGet]
        [Route("AddCity")]
        public IActionResult AddCity()
        {
            return View();
        }

        [HttpGet]
        [Route("AllCity")]
        public async Task<IActionResult> GetAllCity()
        {
            string url = "https://localhost:44348/api/City";
            ////CallApi callApi = new CallApi();
            List<City> cities = new List<City>();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.ResultData;
                cities = JsonConvert.DeserializeObject<List<City>>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpGet]
        [Route("CityById")]
        public async Task<IActionResult> GetCityById(long id)
        {
            string url = "https://localhost:44348/api/City/" + id.ToString();
            City city = new City();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.ResultData;
                city = JsonConvert.DeserializeObject<City>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPost]
        [Route("SaveCity")]
        public async Task<IActionResult> CreateCity([FromBody] CityDto value)
        {
            string url = "https://localhost:44348/api/City";
            City city = new City();
            if(value.Pictures == null)
            {
                value.Pictures = "chuacoanh.png";
            }
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                string result = responseData.ResultData;
                city = JsonConvert.DeserializeObject<City>(result);
                return View();
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPut]
        [Route("UpadateCity")]
        public async Task<IActionResult> UpdateCity([FromBody] City value)
        {
            string url = "https://localhost:44348/api/City/" + value.Id.ToString();
            City city = new City();
            try
            {
                string stringValue = value.ToString();
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                string result = responseData.ResultData;
                city = JsonConvert.DeserializeObject<City>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpDelete]
        [Route("DeleteCity")]
        public async Task<IActionResult> DeleteCity(long id)
        {
            string url = "https://localhost:44348/api/City/" + id.ToString();
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPost]
        [Route("SearchCityTourDetail")]
        public async Task<IActionResult> SearchCity(string searchCitySelect)
        {
            string url = "https://localhost:44348/search/" + searchCitySelect;
            City city = new City();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                string result = responseData.ResultData;
                city = JsonConvert.DeserializeObject<City>(result);
                string stringCity = JsonConvert.SerializeObject(city);
                TempData["CityTourDetail"] = stringCity;
                return RedirectToAction("CityTourDetail", "CityAdmin", new { area = "Admin" });
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

    }
}
