using AutoMapper;
using AutoMapper.QueryableExtensions;
using ECommerce.API.Entities.Dtos;
using ECommerce.API.Entities.Exceptions;
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
            var entity = _mapper.Map<Product>(createProductDto);

            var category = await _repositoryManager.Category.GetCategoryByIdAsync(entity.CategoryId, false);
            if (category is null)
                throw new CategoryNotFoundException(entity.CategoryId);


            entity.ProductCode = GenerateProductCode(category);

            _repositoryManager.Product.CreateOneProduct(entity);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<ProductDto>(entity);
        }

        public async Task DeleteProductAsync(int productId, bool trackChanges)
        {
            var product = await _repositoryManager.Product.GetProductByIdAsync(productId, trackChanges);

            if (product is null)
                throw new ProductNotFoundException(productId);

            _repositoryManager.Product.DeleteOneProduct(product);
            await _repositoryManager.SaveAsync();
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId, bool trackChanges)
        {
            var product = await _repositoryManager.Product.GetProductByIdAsync(productId, trackChanges);
            if (product is null)
                throw new ProductNotFoundException(productId);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductCountBySellerDto> GetProductCountBySellerIdAsync(int sellerId)
        {
            // Burada seller da kontrol edilmeli

            // Buradaki hata zaten olan kullanıcının ID'si ile ürün sayısını alması
            // 2. Ürün sayımı al
            var countDto = await _repositoryManager.Product.GetProductCountBySellerIdAsync(sellerId);

            // 3. Loglama (hiç ürün yoksa bilgi amaçlı)
            if (countDto.TotalProductCount == 0)
            {
                _logger.LogInformation($"Satıcı (ID: {sellerId}) henüz hiç ürün eklememiş.");
            }

            return countDto;
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
                throw new ProductNotFoundException(productId);

            _mapper.Map(updateProductDto, product); // Burada direkt mevcut product'a yazıyoruz
            _repositoryManager.Product.UpdateOneProduct(product);
            await _repositoryManager.SaveAsync();
        }

        private string GenerateProductCode(Category category)
        {
            if (category == null || string.IsNullOrEmpty(category.BaseCode) || string.IsNullOrEmpty(category.Prefix))
            {
                var message = "Category is null or invalid.";
                _logger.LogWarning(message);
                throw new ArgumentException(message);
            }

            var random = new Random();

            // 3 haneli sayı
            string randomDigits = random.Next(100, 999).ToString();

            // Tek karakterlik sembol
            char[] symbols = { '#', '$', '%', '@', '*', '!', '?' };
            char symbol = symbols[random.Next(symbols.Length)];

            return $"{category.Prefix}{category.BaseCode}{randomDigits}{symbol}";
        }
    }
}