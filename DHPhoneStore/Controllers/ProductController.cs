using DHPhoneStore.Models;
using DHPhoneStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace DHPhoneStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var item = await _service.GetAll();
            return Ok(item);
        }

        [HttpGet("GetProductsByCategory/{id}")]
        public async Task<IActionResult> GetProductsByCategory(string id, [FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? brand, [FromQuery] string sortOrder)
        {
            var item = await _service.GetProductsByCategoryAsync(id, page, pageSize, brand, sortOrder);
            return Ok(item);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string query)
        {
            var item = await _service.SearchAsync(page, pageSize, query);
            return Ok(item);
        }

        [HttpGet("GetListSale")]
        public async Task<IActionResult> GetListSale([FromQuery] int page, [FromQuery] int pageSize)
        {
            var item = await _service.GetListSaleAsync(page, pageSize);
            return Ok(item);
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var item = await _service.GetProductByIdAsync(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            var id = await _service.PostProductAsync(product);
            return Ok(new { ProductID = id });
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            var item = await _service.UpdateProductAsync(product);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var item = await _service.DeleteProductAsync(id);
            return Ok(item);
        }

        [HttpGet("GetReviewsByProductId/{id}")]
        public async Task<IActionResult> GetReviewsByProductId(string id)
        {
            var item = await _service.GetReviewsByProductIdAsync(id);
            return Ok(item);
        }
        
    }
}

