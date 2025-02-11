using DHPhoneStore.Models;
using DHPhoneStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace DHPhoneStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var item = await _service.GetAll();
            return Ok(item);
        }

        [HttpGet("GetBrandByCategory/{id}")]
        public async Task<IActionResult> GetBrandByCategory(string id)
        {
            var item = await _service.GetBrandByCategoryAsync(id);
            return Ok(item);
        }

        [HttpGet("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCategorytById(string id)
        {
            var item = await _service.GetCategoryByIdAsync(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] Category category)
        {
            var id = await _service.PostCategoryAsync(category);
            return Ok(new { Category = id });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            var item = await _service.UpdateCategoryAsync(category);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var item = await _service.DeleteCategoryAsync(id);
            return Ok(item);
        }
    }
}

