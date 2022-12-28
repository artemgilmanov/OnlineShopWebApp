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
                new Product(){ImagePath = "/images/product1.png"},
                new Product(){ImagePath = "/images/product2.png"},
                new Product(){ImagePath = "/images/product3.png"},
                new Product(){ImagePath = "/images/product4.png"},
                new Product(){ImagePath = "/images/product5.png"},
                new Product(){ImagePath = "/images/product6.png"},
                new Product(){ImagePath = "/images/product7.png"},
                new Product(){ImagePath = "/images/product8.png"},
                new Product(){ImagePath = "/images/product9.png"},
                new Product(){ImagePath = "/images/product10.png"},
                new Product(){ImagePath = "/images/product11.png"},
                new Product(){ImagePath = "/images/product12.png"}
            });
        }
    }
}
