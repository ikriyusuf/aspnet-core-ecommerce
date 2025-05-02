using ECommerce.API.Data;
using ECommerce.API.Entities.Dtos;
using ECommerce.API.Entities.Model;
using ECommerce.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ECommerce.API.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateOneProduct(Product product) => Create(product);

        public void DeleteOneProduct(Product product) => Remove(product);

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .Include(p => p.Category)
                .Include(p => p.Seller)
                    .ThenInclude(s => s.SellerProfile)
                .ToListAsync();

        public async Task<Product> GetProductByIdAsync(int productId, bool trackChanges) =>
            await FindByCondition(p => p.Id.Equals(productId), trackChanges)
            .Include(p => p.Category)
            .Include(p => p.Seller)
            .ThenInclude(s => s.SellerProfile).SingleOrDefaultAsync();

        public async Task<ProductCountBySellerDto> GetProductCountBySellerIdAsync(int sellerId)
        {
            var counts = await FindByCondition(p => p.SellerId == sellerId, false)
             .GroupBy(p => 1)
             .Select(g => new
             {
                 Total = g.Count(),
                 Active = g.Count(p => p.IsActive)
             }).FirstOrDefaultAsync();

            return new ProductCountBySellerDto
            {
                TotalProductCount = counts?.Total ?? 0,
                ActiveProductCount = counts?.Active ?? 0,
                PassiveProductCount = (counts?.Total ?? 0) - (counts?.Active ?? 0)
            };
        }

        public async Task<List<Product>> GetSortedProductsAsync(string sortBy, bool trackChanges)
        {
            var query = FindByCondition(p => p.IsActive, trackChanges)
             .Include(p => p.Category)
             .Include(p => p.Seller)
                 .ThenInclude(s => s.SellerProfile);

            return await (sortBy?.ToLower() == "desc"
                ? query.OrderByDescending(p => p.Price)
                : query.OrderBy(p => p.Price)).ToListAsync();
        }

        public async Task<int> ProductCountAsync() => Count();

        public void UpdateOneProduct(Product product) => Update(product);
    }
}