using AutenticaAPI.Data.Dto;
using AutenticaAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutenticaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUserDto user)
        {
            var token = await _userService.Login(user);
            return Ok(token);
        }
    }
}
