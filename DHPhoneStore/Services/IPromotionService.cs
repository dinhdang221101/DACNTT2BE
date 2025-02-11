using DHPhoneStore.Models;

namespace DHPhoneStore.Services
{
    public interface IPromotionService
    {
        Task<ResponseBase> GetAll();
        Task<ResponseBase> GetPromotionByIdAsync(string id);
        Task<ResponseBase> PostPromotionAsync(Promotion promotion);
        Task<ResponseBase> UpdatePromotionAsync(Promotion promotion);
        Task<ResponseBase> DeletePromotionAsync(int id);
    }
}