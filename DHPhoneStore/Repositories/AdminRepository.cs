using System;
using DHPhoneStore.Models;

namespace DHPhoneStore.Repositories
{
    public class AdminRepository : IAdminRepository
	{
        private readonly ExcuteSqlClass _excuteSqlClass;
        public AdminRepository(ExcuteSqlClass excuteSqlClass)
        {
            _excuteSqlClass = excuteSqlClass;
        }

        public async Task<object?> OrdersAsync()
        {
            var data = await _excuteSqlClass.StatementQueryAsync<Orders>("get_orders");
            return data;
        }

        public async Task<object?> ReportWeekAsync()
        {
            var data = await _excuteSqlClass.StatementQueryAsync<ReportWeek>("report_week");
            return data;
        }

        public async Task<object?> Top3Async()
        {
            var data = await _excuteSqlClass.StatementQueryAsync<Top3>("top3");
            return data;
        }

        public async Task<object?> UpdateStatusOrderAsync(UpdateOrder req)
        {
            var data = await _excuteSqlClass.StatementExecuteAsync("update_order", req);
            return data;
        }
    }
}

