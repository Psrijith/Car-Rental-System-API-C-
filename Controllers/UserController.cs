using DEMO__ASS9.Models;
using DEMO__ASS9.Services;
using Microsoft.AspNetCore.Mvc;

namespace DEMO__ASS9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // POST api/user/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var result = _userService.RegisterUser(user);
            if (!result) return BadRequest("User already exists.");
            return Ok();
        }

        // POST api/user/login
        [HttpPost("login")]
        public IActionResult Login(string Email,string Password)
        {
            var token = _userService.AuthenticateUser(Email, Password);
            if (string.IsNullOrEmpty(token)) return Unauthorized();

            return Ok(new { token });
        }
    }
}
