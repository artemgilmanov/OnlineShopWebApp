using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Model;

namespace OnlineShop.Db
{
    public class DataBaseContext : DbContext
    {        
        // Access to tables
        public DbSet<ProductViewModel> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options):base (options)
        {
            Database.EnsureCreated(); // creates database with the first request
        }
    }
}
