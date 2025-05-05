using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.API.Entities.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? ProductCode { get; set; }

        [Required]
        public string? Brand { get; set; }

        [Required]
        public string? Model { get; set; }

        // Brand + Model birleştirip ad üretiyoruz
        public string Name => $"{Brand} {Model}";

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public double DiscountRate { get; set; } = 0;

        // 🔥 Stock kontrolü
        private int _stock;

        [Required]
        public int Stock
        {
            get => _stock;
            set
            {
                _stock = value;
                if (_stock <= 0)
                {
                    IsActive = false; // stok sıfır olursa ürün kapalı!
                }
            }
        }

        public string? Color { get; set; }
        public string? Material { get; set; }
        public double? Weight { get; set; }
        public string? Dimensions { get; set; }
        public int? WarrantyPeriod { get; set; }
        public string? Tags { get; set; }
        public string? ImageUrl { get; set; }

        // Kategori ilişkisi
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        // Satıcı (User) ilişkisi
        [Required]
        [ForeignKey("Seller")]
        public int SellerId { get; set; }
        public User Seller { get; set; } = null!;

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Yorumlar
        public ICollection<ProductReview> Reviews { get; set; } = new List<ProductReview>();

        // İstatistikler
        public int ViewsCount { get; set; } = 0;
        public int SoldCount { get; set; } = 0;

        // 🔥 İndirimli fiyat hesaplama
        [NotMapped]
        public decimal DiscountedPrice =>
            Price - (Price * (decimal)(DiscountRate / 100));
    }
}
