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

namespace LarsTravelClient.Controllers
{
    public class RegisterController : Controller
    {
        private CallApi _callApi;
        public RegisterController(CallApi callApi)
        {
            _callApi = callApi;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult RegisterInfo()
        {
            ViewData["RegisterEmail"] = HttpContext.Session.GetString("RegisterUsername");
            return View();
        }
        public IActionResult ConfirmEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterForm([FromBody] Account value)
        {
            string url = "https://localhost:44348/checkEmailExis";
            User User = new User();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                if (responseData.Success)
                {
                    if (responseData.Message.Equals("Success"))
                    {
                        HttpContext.Session.SetString("RegisterUsername", value.Username);
                        HttpContext.Session.SetString("RegisterPassword", value.Password);
                        return Ok(new { success = true, message = "" });
                    }
                    return Ok(new { success = false, message = "" });
                }
                return BadRequest(new { success = false, message = responseData.Message });
            }
            catch (HttpRequestException e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveRegister([Bind] User value)
        {
            string url = "https://localhost:44348/api/User";
            //value.Username = HttpContext.Session.GetString("RegisterUsername");
            //value.Password = HttpContext.Session.GetString("RegisterPassword");
            value.Username = "username";
            value.Password = "password";
            value.Role = "User";
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                if (responseData.Success)
                {
                    if (responseData.Message.Equals("Success"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return RedirectToAction("Register", "Register");
                }
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
