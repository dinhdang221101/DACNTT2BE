using System;
using DHPhoneStore.Models;

namespace DHPhoneStore.Repositories
{
    public interface IAdminRepository
    {
        Task<object?> OrdersAsync();
        Task<object?> ReportWeekAsync();
        Task<object?> Top3Async();
        Task<object?> UpdateStatusOrderAsync(UpdateOrder req);
    }
}

