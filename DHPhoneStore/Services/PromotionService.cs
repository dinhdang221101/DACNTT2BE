using System;
using DHPhoneStore.Models;
using DHPhoneStore.Repositories;

namespace DHPhoneStore.Services
{
	public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _repository;
        public PromotionService(IPromotionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseBase> GetAll()
        {
            var response = new ResponseBase();
            response.Data = await _repository.GetAll();
            return response;
        }

        public async Task<ResponseBase> GetPromotionByIdAsync(string id)
        {
            var response = new ResponseBase();
            response.Data = await _repository.GetPromotionByIdAsync(id);
            return response;
        }

        public async Task<ResponseBase> PostPromotionAsync(Promotion promotion)
        {
            var response = new ResponseBase();
            response.Data = await _repository.PostPromotionAsync(promotion);
            return response;
        }

        public async Task<ResponseBase> UpdatePromotionAsync(Promotion promotion)
        {
            var response = new ResponseBase();
            response.Data = await _repository.UpdatePromotionAsync(promotion);
            return response;
        }

        public async Task<ResponseBase> DeletePromotionAsync(int id)
        {
            var response = new ResponseBase();
            response.Data = await _repository.DeletePromotionAsync(id);
            return response;
        }
    }
}

