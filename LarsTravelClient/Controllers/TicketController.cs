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
    public class TicketController : Controller
    {
        private CallApi _callApi;
        public TicketController(CallApi callApi)
        {
            _callApi = callApi;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTicket()
        {
            string url = "https://localhost:44348/api/Ticket";
            ////CallApi callApi = new CallApi();
            List<Ticket> cities = new List<Ticket>();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.ResultData;
                cities = JsonConvert.DeserializeObject<List<Ticket>>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTicketById(long id)
        {
            string url = "https://localhost:44348/api/Ticket/" + id.ToString();
            Ticket Ticket = new Ticket();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.ResultData;
                Ticket = JsonConvert.DeserializeObject<Ticket>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] TicketDto value)
        {
            string url = "https://localhost:44348/api/Ticket";
            Ticket Ticket = new Ticket();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                string result = responseData.ResultData;
                Ticket = JsonConvert.DeserializeObject<Ticket>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTicket([FromBody] Ticket value)
        {
            string url = "https://localhost:44348/api/Ticket/" + value.Id.ToString();
            Ticket Ticket = new Ticket();
            try
            {
                string stringValue = value.ToString();
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                string result = responseData.ResultData;
                Ticket = JsonConvert.DeserializeObject<Ticket>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTicket(long id)
        {
            string url = "https://localhost:44348/api/Ticket/" + id.ToString();
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
