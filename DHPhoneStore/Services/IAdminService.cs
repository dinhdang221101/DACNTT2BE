using System;
using DHPhoneStore.Models;

namespace DHPhoneStore.Services
{
    public interface IAdminService
    {
        Task<ResponseBase> OrdersAsync();
        Task<ResponseBase> ReportWeekAsync();
        Task<ResponseBase> Top3Async();
        Task<ResponseBase> UpdateStatusOrderAsync(UpdateOrder req);
    }
}

