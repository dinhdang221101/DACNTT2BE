using DHPhoneStore.Models;

namespace DHPhoneStore.Services
{
    public interface ICategoryRepository
    {
        Task<object> GetAll();
        Task<object?> GetBrandByCategoryAsync(string id);
        Task<object?> GetCategoryByIdAsync(string id);
        Task<int> PostCategoryAsync(Category category);
        Task<int> UpdateCategoryAsync(Category category);
        Task<int> DeleteCategoryAsync(int id);
    }
}