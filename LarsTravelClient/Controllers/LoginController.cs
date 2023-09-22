using LarsTravel.Models;
using LarsTravelClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LarsTravelClient.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult CheckLogin([FromBody] Account model)
        {
            try
            {
                if (model.Username == "admin" && model.Password == "password")
                {
                    HttpContext.Session.SetString("username", model.Username);
                    return Ok(new { success = true, message = "Đăng nhập thành công" });
                }
                else
                {
                    return Ok(new { success = false, message = "Tên người dùng hoặc mật khẩu không đúng" });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new { success = false, message = "Không thể kết nối với Server" });
            }
        }

    }
}
