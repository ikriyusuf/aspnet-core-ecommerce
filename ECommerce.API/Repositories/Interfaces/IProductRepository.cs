using ECommerce.API.Entities.Model;

namespace ECommerce.API.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);
        Product? GetProductById(int productId, bool trackChanges);
    }
}
