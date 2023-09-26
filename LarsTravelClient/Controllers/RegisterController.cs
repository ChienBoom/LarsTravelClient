using LarsTravel.Models;
using LarsTravelClient.Commons;
using LarsTravelClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace LarsTravelClient.Areas.Common.Controllers
{
    public class RegisterController : Controller
    {
        private CallApi _callApi;
        public RegisterController(CallApi callApi)
        {
            _callApi = callApi;
        }

        public IActionResult Register(int status, string username, string password)
        {
            ViewData["Status"] = status;
            ViewData["Username"] = username;
            ViewData["Password"] = password;
            return View();
        }

        public IActionResult RegisterInfo()
        {
            string value = TempData["Account"].ToString();
            Account account = JsonConvert.DeserializeObject<Account>(value);
            ViewData["AccountEmail"] = account.Username;
            ViewData["AccountPassword"] = account.Password;
            return View();
        }
        public IActionResult ConfirmEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterForm(Account value)
        {
            string url = "https://localhost:44348/checkEmailExis";
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                if (responseData.Success)
                {
                    ResponseData resultData = JsonConvert.DeserializeObject<ResponseData>(responseData.ResultData);
                    if (resultData.Message.Equals("Success"))
                    {
                        TempData["Account"] = stringValue;
                        return RedirectToAction("RegisterInfo");
                    }
                    return RedirectToAction("Register", new { status = 1, username = value.Username, password = value.Password });
                }
                return RedirectToAction("Register", new { status = 2, username = value.Username, password = value.Password });
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("Register", new { status = 2, username = value.Username, password = value.Password });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveRegister(User value)
        {
            string url = "https://localhost:44348/api/User";
            value.Role = "User";
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                if (responseData.Success)
                {
                    if (responseData.Message.Equals("Success"))
                    {
                        return RedirectToAction("Home", "HomeUser", new { area = "Users" });
                    }
                    return RedirectToAction("Error", "HomeUser", new { area = "Users" });
                }
                return RedirectToAction("Error", "HomeUser", new { area = "Users" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "HomeUser", new { area = "Users" });
            }
        }
    }
}
