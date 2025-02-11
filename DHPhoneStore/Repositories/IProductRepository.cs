using DHPhoneStore.Models;
using System;
namespace DHPhoneStore.Repositories
{
	public interface IProductRepository
	{
        Task<object?> GetAll();
        Task<object?> GetListSaleAsync(int page, int pageSize);
        Task<object?> GetProductByIdAsync(string id);
        Task<object?> GetProductsByCategoryAsync(string id, int page, int pageSize, string? brand, string? sortOrder);
        Task<object?> GetReviewsByProductIdAsync(string id);
        Task<int> PostProductAsync(Product product);
        Task<int> UpdateProductAsync(Product product);
        Task<int> DeleteProductAsync(int id);
        Task<object?> SearchAsync(int page, int pageSize, string query);
    }
}

