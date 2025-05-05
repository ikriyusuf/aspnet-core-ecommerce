namespace ECommerce.API.Repositories.Interfaces
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }

        ICategoryRepository Category { get; }
        Task SaveAsync();
    }
}
