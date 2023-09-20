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
    public class EvaluateController : Controller
    {
        private CallApi _callApi;
        public EvaluateController(CallApi callApi)
        {
            _callApi = callApi;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvaluate()
        {
            string url = "https://localhost:44348/api/Evaluate";
            ////CallApi callApi = new CallApi();
            List<Evaluate> cities = new List<Evaluate>();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.ResultData;
                cities = JsonConvert.DeserializeObject<List<Evaluate>>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEvaluateById(long id)
        {
            string url = "https://localhost:44348/api/Evaluate/" + id.ToString();
            Evaluate Evaluate = new Evaluate();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.ResultData;
                Evaluate = JsonConvert.DeserializeObject<Evaluate>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvaluate([FromBody] EvaluateDto value)
        {
            string url = "https://localhost:44348/api/Evaluate";
            Evaluate Evaluate = new Evaluate();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                string result = responseData.ResultData;
                Evaluate = JsonConvert.DeserializeObject<Evaluate>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvaluate([FromBody] Evaluate value)
        {
            string url = "https://localhost:44348/api/Evaluate/" + value.Id.ToString();
            Evaluate Evaluate = new Evaluate();
            try
            {
                string stringValue = value.ToString();
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                string result = responseData.ResultData;
                Evaluate = JsonConvert.DeserializeObject<Evaluate>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEvaluate(long id)
        {
            string url = "https://localhost:44348/api/Evaluate/" + id.ToString();
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
