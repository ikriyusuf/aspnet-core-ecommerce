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

        public ProductDto GetProductById(int productId, bool trackChanges)
        {
            var product = _repositoryManager.Product.GetProductById(productId, trackChanges);

            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task<IEnumerable<ProductSummaryDto>> GetProductSummariesAsync(bool trackChanges)
        {
            var products = await _repositoryManager.Product.GetAllProducts(trackChanges)
                .ToListAsync();

            var productSummaryDtos = _mapper.Map<IEnumerable<ProductSummaryDto>>(products);

            return productSummaryDtos;
        }
    }
}
