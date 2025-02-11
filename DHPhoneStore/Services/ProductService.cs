using System;
using DHPhoneStore.Models;
using DHPhoneStore.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DHPhoneStore.Services
{
    public class ProductService : IProductService
	{
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
		{
            _repository = repository;
        }

        public async Task<ResponseBase> GetAll()
        {
            var response = new ResponseBase();
            response.Data = await _repository.GetAll();
            return response;
        }

        public async Task<ResponseBase> GetListSaleAsync(int page, int pageSize)
        {
            var response = new ResponseBase();
            response.Data = await _repository.GetListSaleAsync(page, pageSize);
            return response;
        }

        public async Task<ResponseBase> GetProductByIdAsync(string id)
        {
            var response = new ResponseBase();
            response.Data = await _repository.GetProductByIdAsync(id);
            return response;
        }

        public async Task<ResponseBase> GetProductsByCategoryAsync(string id, int page, int pageSize, string? brand, string? sortOrder)
        {
            var response = new ResponseBase();
            response.Data = await _repository.GetProductsByCategoryAsync(id, page, pageSize, brand, sortOrder);
            return response;
        }

        public async Task<ResponseBase> GetReviewsByProductIdAsync(string id)
        {
            var response = new ResponseBase();
            response.Data = await _repository.GetReviewsByProductIdAsync(id);
            return response;
        }
        public async Task<ResponseBase> PostProductAsync(Product product)
        {
            var response = new ResponseBase();
            response.Data = await _repository.PostProductAsync(product);
            return response;
        }

        public async Task<ResponseBase> UpdateProductAsync(Product product)
        {
            var response = new ResponseBase();
            response.Data = await _repository.UpdateProductAsync(product);
            return response;
        }

        public async Task<ResponseBase> DeleteProductAsync(int id)
        {
            var response = new ResponseBase();
            response.Data = await _repository.DeleteProductAsync(id);
            return response;
        }

        public async Task<ResponseBase> SearchAsync(int page, int pageSize, string query)
        {
            var response = new ResponseBase();
            response.Data = await _repository.SearchAsync(page, pageSize, query);
            return response;
        }

        public async Task<ResponseBase> ListAddToPromotionAsync(string id)
        {
            var response = new ResponseBase();
            response.Data = await _repository.ListAddToPromotionAsync(id);
            return response;
        }
    }
}

