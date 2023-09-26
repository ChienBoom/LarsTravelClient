using LarsTravel.Models;
using LarsTravelClient.Commons;
using LarsTravelClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace LarsTravelClient.Controllers
{
    public class LoginController : Controller
    {
        private CallApi _callApi;
        public LoginController(CallApi callApi)
        {
            _callApi = callApi;
        }
        public IActionResult Login(int status, string username, string password)
        {
            ViewData["Status"] = status;
            ViewData["Username"] = username;
            ViewData["Password"] = password;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckLogin(Account value)
        {
            string url = "https://localhost:44348/checkAccountLogin";
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
                        if (resultData.ResultData.Equals("Admin"))
                        {
                            return RedirectToAction("HomeAdmin", "HomeAdmin", new {area = "Admin"});
                        }
                        return RedirectToAction("Home", "HomeUser", new {area = "Users"});
                    }
                    return RedirectToAction("Login", new { status = 1, username = value.Username, password = value.Password });
                }
                return RedirectToAction("Login", new { status = 2, username = value.Username, password = value.Password });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", new { status = 2, username = value.Username, password = value.Password });
            }
        }

    }
}
