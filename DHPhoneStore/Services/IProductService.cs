using System;
using DHPhoneStore.Models;

namespace DHPhoneStore.Services
{
    public interface IProductService
    {
        Task<ResponseBase> GetAll();
        Task<ResponseBase> GetListSaleAsync(int page, int pageSize);
        Task<ResponseBase> GetProductByIdAsync(string id);
        Task<ResponseBase> GetProductsByCategoryAsync(string id, int page, int pageSize, string? brand, string? sortOrder);
        Task<ResponseBase> GetReviewsByProductIdAsync(string id);
        Task<ResponseBase> PostProductAsync(Product product);
        Task<ResponseBase> UpdateProductAsync(Product product);
        Task<ResponseBase> DeleteProductAsync(int id);
        Task<ResponseBase> SearchAsync(int page, int pageSize, string query);
    }
}

