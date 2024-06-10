using E_Commerce_API.Helper;
using E_Commerce_API.Model;
using E_Commerce_API.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDto registrationDto)
        {
            var user = new User
            {
                Username = registrationDto.Username,
                Role = "User"
            };

            await _userService.RegisterAsync(user, registrationDto.Password);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            var token = await _userService.AuthenticateAsync(loginDto.Username, loginDto.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }
    }


}
