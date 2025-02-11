using DHPhoneStore.Models;

namespace DHPhoneStore.Services
{
    public interface IPromotionRepository
    {
        Task<object> GetAll();
        Task<object?> GetPromotionByIdAsync(string id);
        Task<int> PostPromotionAsync(Promotion promotion);
        Task<int> UpdatePromotionAsync(Promotion promotion);
        Task<int> DeletePromotionAsync(int id);
        Task<object?> AddProductsAsync(AddProductsPromotion req);
    }
}