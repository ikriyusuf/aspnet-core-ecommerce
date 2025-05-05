using ECommerce.API.Services.Interfaces;

namespace ECommerce.API.Services.Implementations
{
    public class ServiceManager : IServiceManager
    {

        private readonly IProductService _productService;

        public ServiceManager(IProductService productService)
        {
            _productService = productService;
        }
        public IProductService ProductService => _productService;
    }
}
