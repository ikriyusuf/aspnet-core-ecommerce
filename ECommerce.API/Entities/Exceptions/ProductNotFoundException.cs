namespace ECommerce.API.Entities.Exceptions
{
    public sealed class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int productId) : base($"Ürün bulunamadı. Ürün ID: {productId}.")
        {
        }
    }
}
