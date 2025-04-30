using ECommerce.API.Entities.Dtos;
using ECommerce.API.Entities.Model;

namespace ECommerce.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductSummaryDto>> GetProductSummariesAsync(bool trackChanges);
        ProductDto? GetProductById(int productId, bool trackChanges);
        void CreateProduct(CreateProductDto createProductDto);
        void DeleteProduct(int productId);
        void UpdateProduct(int productId, UpdateProductDto updateProductDto);
        Task<int> ProductCountAsync();
        Task<ProductCountBySellerDto> GetProductCountBySellerIdAsync(int sellerId);
        Task<IEnumerable<ProductSummaryDto>> GetSortedProductsAsync(string sortBy, bool trackChanges);
    }
}
