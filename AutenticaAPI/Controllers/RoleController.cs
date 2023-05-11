using AutenticaAPI.Data.Dto;
using AutenticaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutenticaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(RoleDto role)
        {
            if (role is null)
                throw new ApplicationException("Informe uma role");
            await _roleService.Create(role);
            return Ok("Role criada");
        }
    }
}
