using ExaminantionSystem.DTOS;
using ExaminantionSystem.Services.user;
using ExaminationSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExaminantionSystem.Controllers.user
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthorizeServices _authorizeServices;

        public AuthorizeController(IAuthorizeServices authorizeServices)
        {
            _authorizeServices = authorizeServices;
        }

        // ✅ api/authorize/register
        [HttpPost("register")]
        public ActionResult<ResultViewModel<string>> Register([FromBody] RegisterDto dto)
        {
            var result = _authorizeServices.AddUser(dto);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        // ✅ api/authorize/login
        [HttpPost("login")]
        public ActionResult<ResultViewModel<string>> Login([FromBody] LoginUserDto dto)
        {
            var result = _authorizeServices.Login(dto);
            if (!result.IsSuccess)
                return Unauthorized(result);
            return Ok(result);
        }
        //147#326amira$nk

         

    }
}
