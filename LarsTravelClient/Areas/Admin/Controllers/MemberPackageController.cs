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
    public class MemberPackageController : Controller
    {
        private CallApi _callApi;
        public MemberPackageController(CallApi callApi)
        {
            _callApi = callApi;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMemberPackage()
        {
            string url = "https://localhost:44348/api/MemberPackage";
            ////CallApi callApi = new CallApi();
            List<MemberPackage> cities = new List<MemberPackage>();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.ResultData;
                cities = JsonConvert.DeserializeObject<List<MemberPackage>>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMemberPackageById(long id)
        {
            string url = "https://localhost:44348/api/MemberPackage/" + id.ToString();
            MemberPackage MemberPackage = new MemberPackage();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.ResultData;
                MemberPackage = JsonConvert.DeserializeObject<MemberPackage>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMemberPackage([FromBody] MemberPackageDto value)
        {
            string url = "https://localhost:44348/api/MemberPackage";
            MemberPackage MemberPackage = new MemberPackage();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                string result = responseData.ResultData;
                MemberPackage = JsonConvert.DeserializeObject<MemberPackage>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMemberPackage([FromBody] MemberPackage value)
        {
            string url = "https://localhost:44348/api/MemberPackage/" + value.Id.ToString();
            MemberPackage MemberPackage = new MemberPackage();
            try
            {
                string stringValue = value.ToString();
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                string result = responseData.ResultData;
                MemberPackage = JsonConvert.DeserializeObject<MemberPackage>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMemberPackage(long id)
        {
            string url = "https://localhost:44348/api/MemberPackage/" + id.ToString();
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
