namespace ECommerce.API.Entities.Dtos
{
    public class CreateProductDto
    {
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public double DiscountRate { get; set; } = 0;
        public int Stock { get; set; }
        public string? Color { get; set; }
        public string? Material { get; set; }
        public double? Weight { get; set; }
        public string? Dimensions { get; set; }
        public int? WarrantyPeriod { get; set; }
        public string? Tags { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }

        // Geçici olarak seller id ekliyoruz
        public int SellerId { get; set; } // 💥 geçici çözüm
    }
}
