using System.Threading.Tasks;
using DHPhoneStore.Models;
using DHPhoneStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace DHPhoneStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _service;
        public PromotionController(IPromotionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var item = await _service.GetAll();
            return Ok(item);
        }

        [HttpGet("GetPromotionById/{id}")]
        public async Task<IActionResult> GetPromotionById(string id)
        {
            var item = await _service.GetPromotionByIdAsync(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> PostPromotion([FromBody] Promotion promotion)
        {
            var id = await _service.PostPromotionAsync(promotion);
            return Ok(new { Promotion = id });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePromotion(int id, [FromBody] Promotion promotion)
        {
            var item = await _service.UpdatePromotionAsync(promotion);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            var item = await _service.DeletePromotionAsync(id);
            return Ok(item);
        }

        [HttpPost("AddProducts")]
        public async Task<IActionResult> AddProducts([FromBody] AddProductsPromotion req)
        {
            var item = await _service.AddProductsAsync(req);
            return Ok(item);
        }
    }
}

