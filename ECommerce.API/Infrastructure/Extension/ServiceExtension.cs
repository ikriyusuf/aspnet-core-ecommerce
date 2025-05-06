using ECommerce.API.Repositories.Implementations;
using ECommerce.API.Repositories.Interfaces;
using ECommerce.API.Services.Implementations;
using ECommerce.API.Services.Interfaces;

namespace ECommerce.API.Infrastructure.Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<ICategoryService, CategoryService>();
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerManager>();
        }
    }
}

