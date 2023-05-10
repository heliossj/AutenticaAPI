using AutenticaAPI.Data.Dto;
using AutenticaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet]
        [Authorize]//[Authorize(Roles = "Admin")]
        [Route("Users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpDelete]
        [Route("Delete/{userId}")]
        [Authorize]//[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string userId)
        {
            await _userService.Delete(userId);
            return Ok("Usuário deletado");
        }
    }
}
