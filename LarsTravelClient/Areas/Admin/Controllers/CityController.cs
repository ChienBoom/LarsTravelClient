using LarsTravel.Models;
using LarsTravelClient.Commons;
using LarsTravelClient.Models;
using LarsTravelClient.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LarsTravelClient.Areas.Admin.Controllers
{
    public class CityController : Controller
    {
        private CallApi _callApi;
        public CityController(CallApi callApi)
        {
            _callApi = callApi;
        }

        [HttpGet]
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

    }
}
