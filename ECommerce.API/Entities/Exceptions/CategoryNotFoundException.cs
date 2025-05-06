namespace ECommerce.API.Entities.Exceptions
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int categoryId) : base($"Kategori bulunamadı: Kategori ID: {categoryId}.")
        {
        }
    }
}
