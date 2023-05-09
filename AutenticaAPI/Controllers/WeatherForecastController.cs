using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutenticaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        [Route("TempNow")]
        [Authorize]
        public async Task<IActionResult> TempNow()
        {
            var data = new
            {
                temperatura = 36,
                date = DateTime.Now,
            };
            return Ok(data);
        }
    }
}
