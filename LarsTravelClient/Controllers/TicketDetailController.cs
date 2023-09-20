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
    public class TicketDetailController : Controller
    {
        private CallApi _callApi;
        public TicketDetailController(CallApi callApi)
        {
            _callApi = callApi;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTicketDetail()
        {
            string url = "https://localhost:44348/api/TicketDetail";
            ////CallApi callApi = new CallApi();
            List<TicketDetail> cities = new List<TicketDetail>();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.ResultData;
                cities = JsonConvert.DeserializeObject<List<TicketDetail>>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTicketDetailById(long id)
        {
            string url = "https://localhost:44348/api/TicketDetail/" + id.ToString();
            TicketDetail TicketDetail = new TicketDetail();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.ResultData;
                TicketDetail = JsonConvert.DeserializeObject<TicketDetail>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicketDetail([FromBody] TicketDetailDto value)
        {
            string url = "https://localhost:44348/api/TicketDetail";
            TicketDetail TicketDetail = new TicketDetail();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                string result = responseData.ResultData;
                TicketDetail = JsonConvert.DeserializeObject<TicketDetail>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTicketDetail([FromBody] TicketDetail value)
        {
            string url = "https://localhost:44348/api/TicketDetail/" + value.Id.ToString();
            TicketDetail TicketDetail = new TicketDetail();
            try
            {
                string stringValue = value.ToString();
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                string result = responseData.ResultData;
                TicketDetail = JsonConvert.DeserializeObject<TicketDetail>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTicketDetail(long id)
        {
            string url = "https://localhost:44348/api/TicketDetail/" + id.ToString();
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
