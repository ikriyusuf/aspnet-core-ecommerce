namespace ECommerce.API.Services.Interfaces
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }

    }
}
