using ECommerce.API.Data;
using ECommerce.API.Entities.Dtos;
using ECommerce.API.Entities.Model;
using ECommerce.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<Product> GetAllProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
                    .Include(p => p.Category)
                    .Include(p => p.Seller)
                    .ThenInclude(s => s.SellerProfile);
        }

        public Product? GetProductById(int productId, bool trackChanges)
        {
            return FindByCondition(p => p.Id.Equals(productId), trackChanges)
                    .Include(p => p.Category)
                    .Include(p => p.Seller)
                    .ThenInclude(s => s.SellerProfile)
                    .FirstOrDefault();
        }
    }
}
