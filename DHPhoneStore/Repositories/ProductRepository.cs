using System;
using System.Text;
using Dapper;
using DHPhoneStore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DHPhoneStore.Repositories
{
    public class ProductRepository : IProductRepository
	{
        private readonly ExcuteSqlClass _excuteSqlClass;
        public ProductRepository(ExcuteSqlClass excuteSqlClass)
		{
            _excuteSqlClass = excuteSqlClass;
		}

        public async Task<object?> GetAll()
        {
            var data = await _excuteSqlClass.StatementQueryAsync<Product>("get_all_product");
            return data;
        }

        public async Task<object?> GetListSaleAsync(int page, int pageSize)
        {
            var data = await _excuteSqlClass.StatementQueryAsync<ProductSale>("get_product_sale", new {page = (page - 1) * pageSize, pageSize });
            return data;
        }

        public async Task<object?> GetProductByIdAsync(string id)
        {
            var data = await _excuteSqlClass.StatementQueryAsync<ProductSale>("get_by_id", new { id });
            return data;
        }

        public async Task<object?> GetProductsByCategoryAsync(string id, int page, int pageSize, string? brand, string? sortOrder)
        {
            string sql = await _excuteSqlClass.GetStatementById("get_product_by_category");
            sql = sql.Replace("@brand", brand != null ? $" and Brand = '{brand}' " : "").Replace("@sortOrder", sortOrder == "asc" ? $" ORDER BY p.Price ASC " : $" ORDER BY p.Price DESC ");
            var data = await _excuteSqlClass.QueryAsync<ProductSale>(sql, new {id, page = (page - 1) * pageSize, pageSize });
            return data;
        }

        public async Task<object?> GetReviewsByProductIdAsync(string id)
        {
            var data = await _excuteSqlClass.StatementQueryAsync<ReviewsProduct>("get_reviews_product", new { id });
            return data;
        }
        public async Task<int> PostProductAsync(Product product)
        {
            string sql = await _excuteSqlClass.GetStatementById("post_product");
            var data = await _excuteSqlClass.QueryAsync<int>(sql, new { product.ProductName, product.CategoryID, product.Brand, product.Price, product.Stock, product.Description, product.ImageURL });
            return data.Single();
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            string sql = await _excuteSqlClass.GetStatementById("update_product");
            var data = await _excuteSqlClass.QueryAsync<int>(sql, product);
            return data.SingleOrDefault();
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            string sql = await _excuteSqlClass.GetStatementById("delete_product");
            var data = await _excuteSqlClass.QueryAsync<int>(sql, new { ProductID = id });
            return data.SingleOrDefault();
        }

        public async Task<object?> SearchAsync(int page, int pageSize, string query)
        {
            var data = await _excuteSqlClass.StatementQueryAsync<ProductSale>("get_product_by_search", new { page = (page - 1) * pageSize, pageSize, query });
            return data;
        }

        public async Task<object?> ListAddToPromotionAsync(string id)
        {
            var data = await _excuteSqlClass.StatementQueryAsync<ProductPromotion>("list_add_to_promotion", new {id});
            return data;
        }
    }
}

