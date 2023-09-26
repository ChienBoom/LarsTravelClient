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
    public class CommentController : Controller
    {
        private CallApi _callApi;
        public CommentController(CallApi callApi)
        {
            _callApi = callApi;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComment()
        {
            string url = "https://localhost:44348/api/Comment";
            ////CallApi callApi = new CallApi();
            List<Comment> cities = new List<Comment>();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.ResultData;
                cities = JsonConvert.DeserializeObject<List<Comment>>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentById(long id)
        {
            string url = "https://localhost:44348/api/Comment/" + id.ToString();
            Comment Comment = new Comment();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.ResultData;
                Comment = JsonConvert.DeserializeObject<Comment>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentDto value)
        {
            string url = "https://localhost:44348/api/Comment";
            Comment Comment = new Comment();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                string result = responseData.ResultData;
                Comment = JsonConvert.DeserializeObject<Comment>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment([FromBody] Comment value)
        {
            string url = "https://localhost:44348/api/Comment/" + value.Id.ToString();
            Comment Comment = new Comment();
            try
            {
                string stringValue = value.ToString();
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                string result = responseData.ResultData;
                Comment = JsonConvert.DeserializeObject<Comment>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(long id)
        {
            string url = "https://localhost:44348/api/Comment/" + id.ToString();
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
