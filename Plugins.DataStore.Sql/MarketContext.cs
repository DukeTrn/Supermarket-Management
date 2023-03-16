using Microsoft.EntityFrameworkCore;
using WebApp.Model;

namespace Plugins.DataStore.Sql
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            // seeding some data
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Đồ uống", Description = "Đồ uóng" },
                    new Category { Id = 2, Name = "Thức ăn", Description = "Thức ăn" },
                    new Category { Id = 3, Name = "Đồ lưu niệm", Description = "Đồ lưu niệm" }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product { ProductId = 1, CategoryId = 1, Name = "Trà Lipton", Quantity = 100, Price = 50000 },
                    new Product { ProductId = 2, CategoryId = 1, Name = "Trà Thái", Quantity = 200, Price = 20000 },
                    new Product { ProductId = 3, CategoryId = 1, Name = "Bia Sài Gòn", Quantity = 50, Price = 10000 },
                    new Product { ProductId = 4, CategoryId = 2, Name = "Chân gà xả tắc", Quantity = 300, Price = 100000 },
                    new Product { ProductId = 5, CategoryId = 3, Name = "Móc khóa Hust", Quantity = 100, Price = 20000 }
                );
        }
    }
}