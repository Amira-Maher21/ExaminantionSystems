using ExaminantionSystem.Data;
using ExaminantionSystem.DTOS;
using ExaminantionSystem.Helpers;
using ExaminantionSystem.Services.user;
using ExaminantionSystem.ViewModels;
using ExaminationSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExaminantionSystem.Controllers.user
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginUsersController : Controller
    {
        ILoginUserServices loginUserServices;
 
        public LoginUsersController(ILoginUserServices loginUserServices)
         {
            this.loginUserServices = loginUserServices;
         }

        [HttpPost]
        public IActionResult AddLogin(LoginViewModel loginViewModel)
        {
            try
            {
                // تحقق من صحة البيانات
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                // تحويل ViewModel إلى DTO
                var loginDto = loginViewModel.MapOne<LoginUserDto>();

                // استدعاء الخدمة لإضافة المستخدم
                 loginUserServices.AddUser(loginDto);

                // التحقق من نجاح الإضافة
                // إرجاع نتيجة النجاح إذا تمت الإضافة بنجاح
                return Ok(new { IsSuccess = true, Message = "Login added successfully." });
            }
            catch (Exception ex)
            {
                // معالجة أي استثناءات قد تحدث
                return StatusCode(500, new { IsSuccess = false, Message = ex.Message });
            }
        }
    }




}

