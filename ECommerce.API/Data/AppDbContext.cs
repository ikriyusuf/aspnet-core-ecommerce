using ECommerce.API.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ECommerce.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // 🔗 Tablolar
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SellerProfile> SellerProfiles { get; set; } 
        public DbSet<ProductReview> ProductReviews { get; set; }

        // 🔧 Model ayarları (isteğe bağlı)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - SellerProfile
            modelBuilder.Entity<User>()
                .HasOne(u => u.SellerProfile)
                .WithOne(sp => sp.User)
                .HasForeignKey<SellerProfile>(sp => sp.UserId)
                .OnDelete(DeleteBehavior.Cascade); // ✅ Burası Cascade (mantıklı)

            // Category - Product
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // ✅ Zaten böyle bırakmıştık

            // User (Seller) - Product
            modelBuilder.Entity<User>()
                .HasMany(u => u.Products)
                .WithOne(p => p.Seller)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.Restrict); // ✅ DÜZELTTİK

            // Product - ProductReview
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Reviews)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade); // ✅ Bu kalsın (ürün silinirse yorumları gitsin)

            // User - ProductReview
            modelBuilder.Entity<User>()
                .HasMany<ProductReview>()
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict); // ✅ Kullanıcıyı silerken yorumlara dokunma (manuel işlem gerekirse)
        }
    }
}