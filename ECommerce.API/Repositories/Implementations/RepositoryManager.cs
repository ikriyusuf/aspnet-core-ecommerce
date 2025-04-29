using ECommerce.API.Data;
using ECommerce.API.Repositories.Interfaces;
using System.Runtime.CompilerServices;

namespace ECommerce.API.Repositories.Implementations
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;
        private readonly IProductRepository _productRepository;

        public RepositoryManager(IProductRepository productRepository, AppDbContext context)
        {
            _productRepository = productRepository;
            _context = context;
        }

        public IProductRepository Product => _productRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
