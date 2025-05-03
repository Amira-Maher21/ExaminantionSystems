using ExaminantionSystem.Data;
using ExaminantionSystem.DTOS;
using ExaminantionSystem.Helpers;
using ExaminantionSystem.Services;
using ExaminantionSystem.Services.user;
using ExaminantionSystem.ViewModels;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace ExaminantionSystem.Controllers.user
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginUsersController : Controller
    {
        ILogger<LoginUsersController> _logger;
        public LoginUsersController(ILogger<LoginUsersController> logger)
        {
            _logger = logger;
        }


        //[HttpPost]
        //public IActionResult AddLogin(LoginViewModel loginViewModel)
        //{
        //    try
        //    {

        //        //Validate UserName & Password OR ClassUser

        //        //Generate Token

        //        // تحقق من صحة البيانات
        //        if (!ModelState.IsValid)
        //            return BadRequest(ModelState);

        //        // تحويل ViewModel إلى DTO
        //        var loginDto = loginViewModel.MapOne<LoginUserDto>();

        //        // استدعاء الخدمة لإضافة المستخدم
        //        loginUserServices.AddUser(loginDto);

        //        // التحقق من نجاح الإضافة
        //        // إرجاع نتيجة النجاح إذا تمت الإضافة بنجاح
        //        return Ok(new { IsSuccess = true, Message = "Login added successfully." });
        //    }
        //    catch (Exception ex)
        //    {
        //        // معالجة أي استثناءات قد تحدث
        //        return StatusCode(500, new { IsSuccess = false, Message = ex.Message });
        //    }
        //}


        [HttpGet]
        public ResultViewModel<string> LogIn(string userName, string password)
        {
            _logger.LogInformation("======User is log in=====");

            //validate username & password

            //generate token

            string token = TokenGenerator.GeneratorToken("1", "Ali", "2");

            return ResultViewModel<string>.Sucess(token);
        }

    }


}

