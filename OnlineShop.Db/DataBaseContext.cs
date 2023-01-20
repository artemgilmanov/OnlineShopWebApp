using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Model;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public class DataBaseContext : DbContext
    {        
        // Access to tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FavouriteProduct> FavouriteProducts { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options):base (options)
        {
            Database.Migrate();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product(){ImagePath = "/images/products/product1.png"},
                new Product(){ImagePath = "/images/products/product2.png"},
                new Product(){ImagePath = "/images/products/product3.png"},
                new Product(){ImagePath = "/images/products/product4.png"},
                new Product(){ImagePath = "/images/products/product5.png"},
                new Product(){ImagePath = "/images/products/product6.png"},
                new Product(){ImagePath = "/images/products/product7.png"},
                new Product(){ImagePath = "/images/products/product8.png"},
                new Product(){ImagePath = "/images/products/product9.png"},
                new Product(){ImagePath = "/images/products/product10.png"},
                new Product(){ImagePath = "/images/products/product11.png"},
                new Product(){ImagePath = "/images/products/product12.png"}
            });
        }
    }
}
