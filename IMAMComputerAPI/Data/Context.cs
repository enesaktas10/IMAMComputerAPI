using IMAMComputerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace IMAMComputerAPI.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Basket> Baskets { get; set; }
    }
}
