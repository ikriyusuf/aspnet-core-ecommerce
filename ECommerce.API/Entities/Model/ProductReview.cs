using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Entities.Model
{
    public class ProductReview
    {
        [Key]
        public int Id { get; set; }
        // Ürün ile ilişki
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        // Yorumu yapan kullanıcı ile ilişki
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int Rating { get; set; } // 1 - 5 arası yıldız puanı
        public string? Comment { get; set; } // İsteğe bağlı yorum
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
