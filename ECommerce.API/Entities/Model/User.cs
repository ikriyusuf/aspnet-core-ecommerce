using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Entities.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        // Kimlik bilgileri
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = "customer"; // admin | seller | customer

        // Opsiyonel Profil Bilgileri
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? ProfileImageUrl { get; set; }

        // Hesap Yönetimi
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }
        public SellerProfile SellerProfile { get; set; }= null!;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
