using AutoMapper;
using ECommerce.API.Entities.Dtos.Category;
using ECommerce.API.Repositories.Interfaces;
using ECommerce.API.Services.Interfaces;

namespace ECommerce.API.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;

        public CategoryService(IRepositoryManager repositoryManager, ILoggerService logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges)
        {
            var categories =  await _repositoryManager.Category.GetAllCategoriesAsync(trackChanges);

            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoriesDto;

        }
    }
}
