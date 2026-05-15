using Microsoft.EntityFrameworkCore;
using task1.Models;

namespace task1.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ShoppingItem> ShoppingItems { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}