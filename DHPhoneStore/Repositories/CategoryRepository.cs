using System;
using DHPhoneStore.Models;
using DHPhoneStore.Services;

namespace DHPhoneStore.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
        private readonly ExcuteSqlClass _excuteSqlClass;
        public CategoryRepository(ExcuteSqlClass excuteSqlClass)
        {
            _excuteSqlClass = excuteSqlClass;
        }

        public async Task<object> GetAll()
        {
            var data = await _excuteSqlClass.StatementQueryAsync<Category>("get_all_category");
            return data;
        }

        public async Task<object?> GetBrandByCategoryAsync(string id)
        {
            var data = await _excuteSqlClass.StatementQueryAsync<string>("get_brand_by_category", new {id});
            return data;
        }

        public async Task<object?> GetCategoryByIdAsync(string id)
        {
            var data = await _excuteSqlClass.StatementQueryAsync<Category>("get_category_by_id", new { id });
            return data;
        }

        public async Task<int> PostCategoryAsync(Category category)
        {
            string sql = await _excuteSqlClass.GetStatementById("post_category");
            var data = await _excuteSqlClass.QueryAsync<int>(sql, new { category.CategoryName, category.Description });
            return data.Single();
        }

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            string sql = await _excuteSqlClass.GetStatementById("update_category");
            var data = await _excuteSqlClass.QueryAsync<int>(sql, category);
            return data.SingleOrDefault();
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            string sql = await _excuteSqlClass.GetStatementById("delete_category");
            var data = await _excuteSqlClass.QueryAsync<int>(sql, new { CategoryID = id });
            return data.SingleOrDefault();
        }
    }
}

