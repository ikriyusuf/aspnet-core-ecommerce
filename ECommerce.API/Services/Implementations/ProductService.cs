using AutoMapper;
using AutoMapper.QueryableExtensions;
using ECommerce.API.Entities.Dtos;
using ECommerce.API.Entities.Model;
using ECommerce.API.Repositories.Interfaces;
using ECommerce.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void CreateProduct(CreateProductDto createProductDto)
        {
            Product product = _mapper.Map<Product>(createProductDto);

            _repositoryManager.Product.CreateOneProduct(product);

            _repositoryManager.Save();
        }

        public void DeleteProduct(int productId)
        {
            var product = _repositoryManager.Product.GetProductById(productId, false);

            if (product == null)
                throw new KeyNotFoundException($"Product with id {productId} not found.");

            _repositoryManager.Product.DeleteOneProduct(product);
            _repositoryManager.Save();
        }

        public ProductDto? GetProductById(int productId, bool trackChanges)
        {
            var product = _repositoryManager.Product.GetProductById(productId, trackChanges);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductCountBySellerDto> GetProductCountBySellerIdAsync(int sellerId)
        {
            return await _repositoryManager.Product.GetProductCountBySellerIdAsync(sellerId);
        }

        public async Task<IEnumerable<ProductSummaryDto>> GetProductSummariesAsync(bool trackChanges)
        {
            var products = await _repositoryManager.Product.GetAllProducts(trackChanges)
                .ToListAsync();

            var productSummaryDtos = _mapper.Map<IEnumerable<ProductSummaryDto>>(products);

            return productSummaryDtos;
        }

        public async Task<IEnumerable<ProductSummaryDto>> GetSortedProductsAsync(string sortBy, bool trackChanges)
        {
            try
            {
                var products = await _repositoryManager.Product.GetSortedProductsAsync(sortBy, trackChanges);
                var productSummaryDtos = _mapper.Map<IEnumerable<ProductSummaryDto>>(products);

                return productSummaryDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> ProductCountAsync()
        {
            return await _repositoryManager.Product.ProductCountAsync();
        }

        public void UpdateProduct(int productId, UpdateProductDto updateProductDto)
        {
            var product = _repositoryManager.Product.GetProductById(productId, true);

            if (product == null)
                throw new KeyNotFoundException($"Product with id {productId} not found.");

            _mapper.Map(updateProductDto, product); // Burada direkt mevcut product'a yazıyoruz
            _repositoryManager.Product.UpdateOneProduct(product);
            _repositoryManager.Save();
        }
    }
}