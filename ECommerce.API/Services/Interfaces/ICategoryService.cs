using ECommerce.API.Entities.Dtos.Category;
using ECommerce.API.Entities.Model;

namespace ECommerce.API.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges);
    }
}
