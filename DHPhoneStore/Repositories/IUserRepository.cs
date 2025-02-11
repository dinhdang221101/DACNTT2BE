using System;
using DHPhoneStore.Models;

namespace DHPhoneStore.Repositories
{
    public interface IUserRepository
    {
        Task<int> AddToCartAsync(AddToCart req);
        Task<object?> CartAsync(int userID);
        Task<object?> CheckoutAsync(UserOrder req);
        Task<List<StockProduct>?> FirstCheckoutAsync(List<CartUser> req);
        Task<object?> LoginUserAsync(User user);
        Task<object?> OrderHistoryAsync(string userID);
        Task<object?> RegisterUserAsync(User user);
        Task<object?> SubmitReviewAsync(ReviewProduct req);
        Task<object?> UpdateOrderStatus(Dictionary<string, string> queryParams);
        Task<object> GetAll();
        Task<object?> GetUserByIdAsync(string id);
        Task<int> PostUserAsync(User user);
        Task<int> UpdateUserAsync(User user);
        Task<int> DeleteUserAsync(int id);
        
    }
}

