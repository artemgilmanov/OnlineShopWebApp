using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Model;

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
            Database.EnsureCreated(); // creates database with the first request
        }
    }
}
