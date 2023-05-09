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

        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> Update(int id){
            return Ok("teste");
        }

        [HttpPut]
        [Route("Update")]
        [Authorize]
        public async Task<IActionResult>Update(int id,  CreateUserDto userDto)
        {
            return Ok("ok");
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok("teste");
        }

        [HttpPut]
        //[Route("Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int id, CreateUserDto userDto)
        {
            return Ok("ok");
        }





    }
}
