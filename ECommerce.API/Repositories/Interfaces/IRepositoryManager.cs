namespace ECommerce.API.Repositories.Interfaces
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        void Save();
    }
}
