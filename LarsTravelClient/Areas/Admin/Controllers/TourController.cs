using LarsTravel.Models;
using LarsTravelClient.Commons;
using LarsTravelClient.Models;
using LarsTravelClient.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace LarsTravelClient.Controllers
{
    public class TourController : Controller
    {
        private CallApi _callApi;
        public TourController(CallApi callApi)
        {
            _callApi = callApi;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTour()
        {
            string url = "https://localhost:44348/api/Tour";
            ////CallApi callApi = new CallApi();
            List<Tour> cities = new List<Tour>();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.ResultData;
                cities = JsonConvert.DeserializeObject<List<Tour>>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTourById(long id)
        {
            string url = "https://localhost:44348/api/Tour/" + id.ToString();
            Tour Tour = new Tour();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.ResultData;
                Tour = JsonConvert.DeserializeObject<Tour>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTour([FromBody] TourDto value)
        {
            string url = "https://localhost:44348/api/Tour";
            Tour Tour = new Tour();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                string result = responseData.ResultData;
                Tour = JsonConvert.DeserializeObject<Tour>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTour([FromBody] Tour value)
        {
            string url = "https://localhost:44348/api/Tour/" + value.Id.ToString();
            Tour Tour = new Tour();
            try
            {
                string stringValue = value.ToString();
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                string result = responseData.ResultData;
                Tour = JsonConvert.DeserializeObject<Tour>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTour(long id)
        {
            string url = "https://localhost:44348/api/Tour/" + id.ToString();
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
