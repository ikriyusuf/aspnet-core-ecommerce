using ECommerce.API.Entities.Model;

namespace ECommerce.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);

        Task<Category> GetCategoryByIdAsync(int categoryId, bool trackChanges);
    }
}
