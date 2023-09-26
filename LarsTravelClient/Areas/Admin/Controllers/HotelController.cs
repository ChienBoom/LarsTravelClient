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
    public class HotelController : Controller
    {
        private CallApi _callApi;
        public HotelController(CallApi callApi)
        {
            _callApi = callApi;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotel()
        {
            string url = "https://localhost:44348/api/Hotel";
            ////CallApi callApi = new CallApi();
            List<Hotel> cities = new List<Hotel>();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.ResultData;
                cities = JsonConvert.DeserializeObject<List<Hotel>>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetHotelById(long id)
        {
            string url = "https://localhost:44348/api/Hotel/" + id.ToString();
            Hotel Hotel = new Hotel();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.ResultData;
                Hotel = JsonConvert.DeserializeObject<Hotel>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] HotelDto value)
        {
            string url = "https://localhost:44348/api/Hotel";
            Hotel Hotel = new Hotel();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                string result = responseData.ResultData;
                Hotel = JsonConvert.DeserializeObject<Hotel>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHotel([FromBody] Hotel value)
        {
            string url = "https://localhost:44348/api/Hotel/" + value.Id.ToString();
            Hotel Hotel = new Hotel();
            try
            {
                string stringValue = value.ToString();
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                string result = responseData.ResultData;
                Hotel = JsonConvert.DeserializeObject<Hotel>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHotel(long id)
        {
            string url = "https://localhost:44348/api/Hotel/" + id.ToString();
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
