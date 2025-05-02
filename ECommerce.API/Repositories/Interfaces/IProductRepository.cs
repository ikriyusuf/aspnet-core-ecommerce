using ECommerce.API.Entities.Dtos;
using ECommerce.API.Entities.Model;

namespace ECommerce.API.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);
        Task<Product> GetProductByIdAsync(int productId, bool trackChanges);
        void CreateOneProduct(Product product);
        void DeleteOneProduct(Product product);
        void UpdateOneProduct(Product product);
        Task<int> ProductCountAsync();
        Task<ProductCountBySellerDto> GetProductCountBySellerIdAsync(int sellerId);
        Task<List<Product>> GetSortedProductsAsync(string sortBy, bool trackChanges);
    }
}
