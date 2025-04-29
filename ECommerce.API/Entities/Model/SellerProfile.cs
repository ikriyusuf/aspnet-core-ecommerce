using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Entities.Model
{
    public class SellerProfile
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        // Mağaza Bilgileri
        public string ShopName { get; set; } = null!;
        public string? ShopDescription { get; set; }
        public string? ShopLogoUrl { get; set; }
        public string? ShopBannerUrl { get; set; }

        // Mağaza İletişim Bilgileri
        public string? ShopPhoneNumber { get; set; }    // DÜKKAN telefon numarası
        public string? ShopEmail { get; set; }          // DÜKKAN email adresi
        public string? ShopAddress { get; set; }         // DÜKKAN adresi

        // Satıcı Durum Bilgisi
        public bool IsVerified { get; set; } = false;
        public bool IsActive { get; set; } = true;

        // Puanlama
        public decimal AverageRating { get; set; } = 0;
        public int TotalReviews { get; set; } = 0;

    }
}
