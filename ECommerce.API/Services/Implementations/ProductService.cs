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
        private readonly ILoggerService _logger;

        public ProductService(IRepositoryManager repositoryManager, IMapper mapper, ILoggerService logger)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            var entity  = _mapper.Map<Product>(createProductDto);

            _repositoryManager.Product.CreateOneProduct(entity);

            await _repositoryManager.SaveAsync();

            return _mapper.Map<ProductDto>(entity);
        }

        public async Task DeleteProductAsync(int productId, bool trackChanges)
        {
            var product = await _repositoryManager.Product.GetProductByIdAsync(productId, trackChanges);

            if (product is null)
            {
                string message = $"Product with id {productId} not found.";
                _logger.LogInformation(message);
                throw new KeyNotFoundException(message);
            }
            _repositoryManager.Product.DeleteOneProduct(product);
            await _repositoryManager.SaveAsync();
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId, bool trackChanges)
        {
            var product = await _repositoryManager.Product.GetProductByIdAsync(productId, trackChanges);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductCountBySellerDto> GetProductCountBySellerIdAsync(int sellerId)
        {
            return await _repositoryManager.Product.GetProductCountBySellerIdAsync(sellerId);
        }

        public async Task<IEnumerable<ProductSummaryDto>> GetProductSummariesAsync(bool trackChanges)
        {
            var products = await _repositoryManager.Product.GetAllProductsAsync(trackChanges);
                
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

        public async Task UpdateProductAsync(int productId, UpdateProductDto updateProductDto, bool trackChanges)
        {
            var product = await _repositoryManager.Product.GetProductByIdAsync(productId, trackChanges);

            if (product is null)
                throw new KeyNotFoundException($"Product with id {productId} not found.");

            _mapper.Map(updateProductDto, product); // Burada direkt mevcut product'a yazıyoruz
            _repositoryManager.Product.UpdateOneProduct(product);
            await _repositoryManager.SaveAsync();
        }
    }
}