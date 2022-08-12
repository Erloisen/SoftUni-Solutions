using Microsoft.EntityFrameworkCore;
using ProductShop.Data.Models.Models;

namespace ProductShop.Data
{
    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {
        }

        public ProductShopContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(cp => new { cp.CategoryId, cp.ProductId });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(x => x.ProductsBougth)
                    .WithOne(x => x.Buyer)
                    .HasForeignKey(x => x.BuyerId);

                entity.HasMany(x => x.ProductsSold)
                    .WithOne(x => x.Seller)
                    .HasForeignKey(x => x.SellerId);
            });
        }
    }
}
