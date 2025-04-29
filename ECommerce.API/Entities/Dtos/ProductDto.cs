using ECommerce.API.Entities.Model;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Entities.Dtos
{
    public class ProductDto
    {
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Name { get; set; } = null!; 
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public double DiscountRate { get; set; }
        public decimal DiscountedPrice { get; set; } 
        public int Stock { get; set; }
        public string? Color { get; set; }
        public string? Material { get; set; }
        public double? Weight { get; set; }
        public string? Dimensions { get; set; }
        public int? WarrantyPeriod { get; set; }
        public string? Tags { get; set; }
        public string? ImageUrl { get; set; }
        public string CategoryName { get; set; } = null!;
        public string SellerShopName { get; set; } = null!;
        public bool IsActive { get; set; }
        // İstatistikler
        public int ViewsCount { get; set; }
        public int SoldCount { get; set; }
    }
}

