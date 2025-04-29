namespace ECommerce.API.Entities.Dtos
{
    public class ProductSummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; // Brand + Model birleşimi
        public decimal Price { get; set; }
        public double DiscountRate { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string? ImageUrl { get; set; }
        public string CategoryName { get; set; } = null!;
        public string SellerShopName { get; set; } = null!; // Eğer göstereceksen
    }
}
