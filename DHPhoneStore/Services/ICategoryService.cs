using DHPhoneStore.Models;

namespace DHPhoneStore.Services
{
    public interface ICategoryService
    {
        Task<ResponseBase> GetAll();
        Task<ResponseBase> GetBrandByCategoryAsync(string id);
        Task<ResponseBase> GetCategoryByIdAsync(string id);
        Task<ResponseBase> PostCategoryAsync(Category category);
        Task<ResponseBase> UpdateCategoryAsync(Category category);
        Task<ResponseBase> DeleteCategoryAsync(int id);
    }
}