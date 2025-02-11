using System;
using DHPhoneStore.Models;
using DHPhoneStore.Repositories;

namespace DHPhoneStore.Services
{
    public class AdminService : IAdminService
	{
        private readonly IAdminRepository _repository;
        public AdminService(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseBase> OrdersAsync()
        {
            var response = new ResponseBase();
            response.Data = await _repository.OrdersAsync();
            return response;
        }

        public async Task<ResponseBase> ReportWeekAsync()
        {
            var response = new ResponseBase();
            response.Data = await _repository.ReportWeekAsync();
            return response;
        }

        public async Task<ResponseBase> Top3Async()
        {
            var response = new ResponseBase();
            response.Data = await _repository.Top3Async();
            return response;
        }

        public async Task<ResponseBase> UpdateStatusOrderAsync(UpdateOrder req)
        {
            var response = new ResponseBase();
            response.Data = await _repository.UpdateStatusOrderAsync(req);
            return response;
        }
    }
}

