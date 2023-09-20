using LarsTravel.Models;
using LarsTravelClient.Commons;
using LarsTravelClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
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
        public IActionResult ConfirmEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterForm([FromBody] Account value)
        {
            try 
            {
                string url = "https://localhost:44348/api/User/checkEmailExis";
                User User = new User();
                try
                {
                    string stringValue = JsonConvert.SerializeObject(value);
                    ResponseData responseData = await _callApi.PostApi(url, stringValue);
                    if (responseData.Success)
                    {
                        if(responseData.Message.Equals("Success")) return RedirectToAction("ConfirmEmail", "Register");
                        return RedirectToAction("Register", "Register");
                    }
                    return RedirectToAction("Error", "Register");
                }
                catch (HttpRequestException e)
                {
                    return View();
                }
                //if (model.Username == "admin" && model.Password == "password")
                //{
                //    HttpContext.Session.SetString("emailRegister", model.Username);
                //    return Ok(new { success = true, message = "Đăng ký với email thành công" });
                //}
                //else
                //{
                //    return Ok(new { success = false, message = "Email đã được sử dụng" });
                //}
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Không thể kết nối với Server" });
            }
        }

    }
}
