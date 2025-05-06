namespace ECommerce.UI.Models.ViewModels.Product
{
    public class ProductSummaryViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string SellerShopName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public double DiscountRate { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string? ImageUrl { get; set; }
    }
}
