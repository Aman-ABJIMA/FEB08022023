using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get;set; }
        public DbSet<User> User { get; set; }
    }
}
