using Microsoft.EntityFrameworkCore;
using PangWeb.Shared;

namespace PangWeb.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<ItemPurchase> ItemPurchases { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBasket> OrderBaskets { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
