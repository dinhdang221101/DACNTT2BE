using System;
using DHPhoneStore.Models;
using DHPhoneStore.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DHPhoneStore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public class PasswordHasher
        {
            public static string HashPassword(string password)
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            }

            public static bool VerifyPassword(string password, string hashedPassword)
            {
                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }
        }
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseBase> RegisterUserAsync(User user)
        {
            var response = new ResponseBase();
            user.Password = PasswordHasher.HashPassword(user.Password);
            response.Data = await _repository.RegisterUserAsync(user);
            if (response.Data == null)
            {
                response.Status = "02";
                response.Message = "Email hoặc số điện thoại này đã được đăng ký";
            }
            return response;
        }

        public async Task<ResponseBase> LoginUserAsync(User user)
        {
            var response = new ResponseBase();
            User u = (User)await _repository.LoginUserAsync(user);
            if (u != null && PasswordHasher.VerifyPassword(user.Password, u.Password))
            {
                response.Status = "00";
                response.Data = u;
            }
            else
            {
                response.Status = "02";
                response.Message = "Tài khoản hoặc mật khẩu không chính xác.";
            }
            return response;
        }

        public async Task<ResponseBase> AddToCartAsync(AddToCart req)
        {
            var response = new ResponseBase();
            var res = await _repository.AddToCartAsync(req);
            if (res == 0)
            {
                response.Status = "02";
                response.Message = "Thêm vào giỏ hàng thất bại do vượt quá số lượng tồn kho";
            }
            return response;
        }

        public async Task<ResponseBase> CartAsync(int userID)
        {
            var response = new ResponseBase();
            response.Data = await _repository.CartAsync(userID);
            return response;
        }

        public async Task<ResponseBase> FirstCheckoutAsync(List<CartUser> req)
        {
            var response = new ResponseBase();
            response.Data = await _repository.FirstCheckoutAsync(req);
            return response;
        }

        public async Task<ResponseBase> CheckoutAsync(UserOrder req)
        {
            var response = new ResponseBase();
            response.Data = await _repository.CheckoutAsync(req);
            return response;
        }

        public async Task<ResponseBase> OrderHistoryAsync(string userID)
        {
            var response = new ResponseBase();
            response.Data = await _repository.OrderHistoryAsync(userID);
            return response;
        }

        public async Task<ResponseBase> SubmitReviewAsync(ReviewProduct req)
        {
            var response = new ResponseBase();
            response.Data = await _repository.SubmitReviewAsync(req);
            return response;
        }

        public async Task<ResponseBase> UpdateOrderStatus(Dictionary<string, string> queryParams)
        {
            var response = new ResponseBase();
            response.Data = await _repository.UpdateOrderStatus(queryParams);
            return response;
        }

        public async Task<ResponseBase> GetAll()
        {
            var response = new ResponseBase();
            response.Data = await _repository.GetAll();
            return response;
        }

        public async Task<ResponseBase> GetUserByIdAsync(string id)
        {
            var response = new ResponseBase();
            response.Data = await _repository.GetUserByIdAsync(id);
            return response;
        }

        public async Task<ResponseBase> PostUserAsync(User user)
        {
            var response = new ResponseBase();
            user.Password = PasswordHasher.HashPassword(user.Password);
            response.Data = await _repository.PostUserAsync(user);
            return response;
        }

        public async Task<ResponseBase> UpdateUserAsync(User user)
        {
            var response = new ResponseBase();

            // Kiểm tra nếu mật khẩu mới được cung cấp
            if (!string.IsNullOrEmpty(user.Password))
            {
                user.Password = PasswordHasher.HashPassword(user.Password);

            }
            else
            {
                // Không cập nhật mật khẩu nếu không có mật khẩu mới
                user.Password = null;
            }

            response.Data = await _repository.UpdateUserAsync(user);
            return response;
        }

        public async Task<ResponseBase> DeleteUserAsync(int id)
        {
            var response = new ResponseBase();
            response.Data = await _repository.DeleteUserAsync(id);
            return response;
        }
    }
}

