
using DHPhoneStore.Models;
using DHPhoneStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace DHPhoneStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;
        public AdminController(IAdminService service)
        {
            _service = service;
        }

        [HttpGet("reportWeek")]
        public async Task<IActionResult> ReportWeek()
        {
            var item = await _service.ReportWeekAsync();
            return Ok(item);
        }

        [HttpGet("top3")]
        public async Task<IActionResult> Top3()
        {
            var item = await _service.Top3Async();
            return Ok(item);
        }

        [HttpGet("orders")]
        public async Task<IActionResult> Orders()
        {
            var item = await _service.OrdersAsync();
            return Ok(item);
        }

        [HttpPost("orders")]
        public async Task<IActionResult> UpdateStatusOrder([FromBody] UpdateOrder req)
        {
            var item = await _service.UpdateStatusOrderAsync(req);
            return Ok(item);
        }
    }
}

