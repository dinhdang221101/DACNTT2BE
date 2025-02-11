using System;
using DHPhoneStore.Models;

namespace DHPhoneStore.Repositories
{
    public class UserRepository : IUserRepository
	{
        private readonly ExcuteSqlClass _excuteSqlClass;
        public UserRepository(ExcuteSqlClass excuteSqlClass)
        {
            _excuteSqlClass = excuteSqlClass;
        }

        public async Task<int> AddToCartAsync(AddToCart req)
        {
            int data = (int)await _excuteSqlClass.StatementExecuteAsync("add_to_cart", req);
            return data;
        }

        public async Task<object?> CartAsync(int userID)
        {
            var data = await _excuteSqlClass.StatementQueryAsync<CartUser>("get_cart_user", new { userID });
            return data;
        }

        public async Task<object?> CheckoutAsync(UserOrder req)
        {
            var data = await _excuteSqlClass.StatementQueryAsync<int>("checkout", req);
            foreach(ProductOrder product in req.Products)
            {
                product.OrderID = data.FirstOrDefault();
                await _excuteSqlClass.StatementExecuteAsync("add_to_order_detail", product);
                await _excuteSqlClass.StatementExecuteAsync("delete_from_cart", new {UserID = req.UserID, ProductID = product.ProductID});
            }
            return data.FirstOrDefault();
        }

        public async Task<List<StockProduct>?> FirstCheckoutAsync(List<CartUser> req)
        {
            List<StockProduct> ret = new List<StockProduct>();
            foreach (CartUser cartUser in req)
            {
                var data = await _excuteSqlClass.StatementQueryAsync<StockProduct>("check_first_checkout", cartUser);
                if(data.FirstOrDefault() != null)
                {
                    ret.Add(data.FirstOrDefault());
                }
            }
            return ret;
        }

        public async Task<object?> LoginUserAsync(User user)
        {
            var data = await _excuteSqlClass.StatementQueryAsync<User>("login_user", user);
            return data.FirstOrDefault();   
        }

        public async Task<object?> OrderHistoryAsync(string userID)
        {
            var data = await _excuteSqlClass.StatementQueryAsync<UserHistory>("order_history", new { userID });
            return data.GroupBy(i => i.OrderID).ToList();
        }

        public async Task<object?> RegisterUserAsync(User user)
        {
            var data = await _excuteSqlClass.StatementExecuteAsync("register_user", user);
            return data;
        }

        public async Task<object?> SubmitReviewAsync(ReviewProduct req)
        {
            var data = await _excuteSqlClass.StatementExecuteAsync("review_product", req);
            return data;
        }

        public async Task<object?> UpdateOrderStatus(Dictionary<string, string> queryParams)
        {
            var paras = new
            {
                OrderID = queryParams.TryGetValue("vnp_TxnRef", out string value) ? value.Split("_")[0] : null,
                PaymentStatus = queryParams.TryGetValue("vnp_ResponseCode", out string code) ? (code == "00" ? "completed" : "failed") : "failed",
                PaymentTransactionID = queryParams.TryGetValue("vnp_TransactionNo", out string trans) ? trans : null,
                OrderStatus = (code == "00" ? "processing" : "pending"),
            };
            var data = await _excuteSqlClass.StatementExecuteAsync("update_status_order", paras);
            return data;
        }

        public async Task<object> GetAll()
        {
            var data = await _excuteSqlClass.StatementQueryAsync<User>("get_all_user");
            return data;
        }

        public async Task<object?> GetUserByIdAsync(string id)
        {
            var data = await _excuteSqlClass.StatementQueryAsync<User>("get_user_by_id", new { id });
            return data;
        }

        public async Task<int> PostUserAsync(User user)
        {
            string sql = await _excuteSqlClass.GetStatementById("post_user");
            var data = await _excuteSqlClass.QueryAsync<int>(sql, new { user.Name, user.Email, user.Password, user.Phone, user.Role });
            return data.Single();
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            string sql = await _excuteSqlClass.GetStatementById("update_user");
            // Loại bỏ trường PasswordHash nếu không cập nhật mật khẩu
            if (user.Password == null)
            {
                sql = sql.Replace("PasswordHash = @Password,", "");
            }
            var data = await _excuteSqlClass.QueryAsync<int>(sql, user);
            return data.SingleOrDefault();
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            string sql = await _excuteSqlClass.GetStatementById("delete_user");
            var data = await _excuteSqlClass.QueryAsync<int>(sql, new { UserID = id });
            return data.SingleOrDefault();
        }
    }
}

