using ECommerce.API.Data;
using ECommerce.API.Entities.Model;
using ECommerce.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repositories.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges) => 
            await FindAll(trackChanges).ToListAsync();

        public async Task<Category> GetCategoryByIdAsync(int categoryId, bool trackChanges)=> 
           await FindByCondition(c => c.Id.Equals(categoryId), trackChanges)
                .SingleOrDefaultAsync();
    }
}
