using AutenticaAPI.Data.Dto;
using AutenticaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutenticaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        //[AllowAnonymous]
        public async Task<IActionResult> Register(CreateUserDto user)
        {
            await _userService.Register(user);
            return Ok("Usuário cadastrado");
        }
    }
}
