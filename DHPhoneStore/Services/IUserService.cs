using System;
using DHPhoneStore.Models;

namespace DHPhoneStore.Services
{
    public interface IUserService
    {
        Task<ResponseBase> AddToCartAsync(AddToCart req);
        Task<ResponseBase> CartAsync(int UserID);
        Task<ResponseBase> CheckoutAsync(UserOrder req);
        Task<ResponseBase> FirstCheckoutAsync(List<CartUser> req);
        Task<ResponseBase> LoginUserAsync(User user);
        Task<ResponseBase> OrderHistoryAsync(string userID);
        Task<ResponseBase> RegisterUserAsync(User user);
        Task<ResponseBase> SubmitReviewAsync(ReviewProduct req);
        Task<ResponseBase> UpdateOrderStatus(Dictionary<string, string> queryParams);
        Task<ResponseBase> GetAll();
        Task<ResponseBase> GetUserByIdAsync(string id);
        Task<ResponseBase> PostUserAsync(User user);
        Task<ResponseBase> UpdateUserAsync(User user);
        Task<ResponseBase> DeleteUserAsync(int id);
    }
}

