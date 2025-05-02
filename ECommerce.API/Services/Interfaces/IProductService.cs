using ECommerce.API.Entities.Dtos;
using ECommerce.API.Entities.Model;

namespace ECommerce.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductSummaryDto>> GetProductSummariesAsync(bool trackChanges);
        Task<ProductDto> GetProductByIdAsync(int productId, bool trackChanges);
        Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto);
        Task DeleteProductAsync(int productId,bool trackChanges);
        Task UpdateProductAsync(int productId, UpdateProductDto updateProductDto,bool trackChanges);
        Task<int> ProductCountAsync();
        Task<ProductCountBySellerDto> GetProductCountBySellerIdAsync(int sellerId);
        Task<IEnumerable<ProductSummaryDto>> GetSortedProductsAsync(string sortBy, bool trackChanges);
    }
}
