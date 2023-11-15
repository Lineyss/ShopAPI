using Microsoft.EntityFrameworkCore;

namespace ShopAPI2.Models.DataBaseModels
{
    public class DataBaseWorker : DbContext
    {
        public DataBaseWorker(DbContextOptions<DataBaseWorker> options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<Order_Product> order_products { get; set; }
        public DbSet<Status> status { get; set; }
    }
}
