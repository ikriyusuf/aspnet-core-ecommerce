using ECommerce.API.Entities.Dtos;
using ECommerce.API.Entities.Model;

namespace ECommerce.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductSummaryDto>> GetProductSummariesAsync(bool trackChanges);
    }
}
