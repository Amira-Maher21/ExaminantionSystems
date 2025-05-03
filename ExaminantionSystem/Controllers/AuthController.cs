using ExaminantionSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminantionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _tokenService;

        public AuthController(JwtTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Simulate user authentication (replace with real logic)
            if (request.Username == "admin" && request.Password == "password")
            {
                // Generate JWT token
                var token = _tokenService.GenerateToken("1", "Admin");

                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials.");
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
