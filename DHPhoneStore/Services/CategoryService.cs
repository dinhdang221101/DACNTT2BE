using System;
using DHPhoneStore.Models;
using DHPhoneStore.Repositories;

namespace DHPhoneStore.Services
{
	public class CategoryService : ICategoryService
	{
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseBase> GetAll()
        {
            var response = new ResponseBase();
            response.Data = await _repository.GetAll();
            return response;
        }

        public async Task<ResponseBase> GetBrandByCategoryAsync(string id)
        {
            var response = new ResponseBase();
            response.Data = await _repository.GetBrandByCategoryAsync(id);
            return response;
        }

        public async Task<ResponseBase> GetCategoryByIdAsync(string id)
        {
            var response = new ResponseBase();
            response.Data = await _repository.GetCategoryByIdAsync(id);
            return response;
        }

        public async Task<ResponseBase> PostCategoryAsync(Category category)
        {
            var response = new ResponseBase();
            response.Data = await _repository.PostCategoryAsync(category);
            return response;
        }

        public async Task<ResponseBase> UpdateCategoryAsync(Category category)
        {
            var response = new ResponseBase();
            response.Data = await _repository.UpdateCategoryAsync(category);
            return response;
        }

        public async Task<ResponseBase> DeleteCategoryAsync(int id)
        {
            var response = new ResponseBase();
            response.Data = await _repository.DeleteCategoryAsync(id);
            return response;
        }
    }
}

