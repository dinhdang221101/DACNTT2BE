using System;
using DHPhoneStore.Models;
using DHPhoneStore.Services;

namespace DHPhoneStore.Repositories
{
	public class PromotionRepository : IPromotionRepository
    {
        private readonly ExcuteSqlClass _excuteSqlClass;
        public PromotionRepository(ExcuteSqlClass excuteSqlClass)
        {
            _excuteSqlClass = excuteSqlClass;
        }

        public async Task<object> GetAll()
        {
            var data = await _excuteSqlClass.StatementQueryAsync<Promotion>("get_all_promotion");
            return data;
        }

        public async Task<object?> GetPromotionByIdAsync(string id)
        {
            var data = await _excuteSqlClass.StatementQueryAsync<Promotion>("get_promotion_by_id", new { id });
            return data;
        }

        public async Task<int> PostPromotionAsync(Promotion promotion)
        {
            string sql = await _excuteSqlClass.GetStatementById("post_promotion");
            var data = await _excuteSqlClass.QueryAsync<int>(sql, new { promotion.PromotionName, promotion.DiscountPercent, promotion.StartDate, promotion.EndDate });
            return data.Single();
        }

        public async Task<int> UpdatePromotionAsync(Promotion promotion)
        {
            string sql = await _excuteSqlClass.GetStatementById("update_promotion");
            var data = await _excuteSqlClass.QueryAsync<int>(sql, promotion);
            return data.SingleOrDefault();
        }

        public async Task<int> DeletePromotionAsync(int id)
        {
            string sql = await _excuteSqlClass.GetStatementById("delete_promotion");
            var data = await _excuteSqlClass.QueryAsync<int>(sql, new { PromotionID = id });
            return data.SingleOrDefault();
        }

        public async Task<object?> AddProductsAsync(AddProductsPromotion req)
        {
            List<ListAddProductPromotion> list = new List<ListAddProductPromotion>();
            await _excuteSqlClass.StatementExecuteAsync("delete_product_to_promotion", new {id = req.PromotionID});
            foreach(int id in req.ProductIDs)
            {
                await _excuteSqlClass.StatementQueryAsync<Promotion>("add_product_to_promotion", new { ProductID = id, PromotionID = req.PromotionID});
            }
            return 1;
        }
    }
}

