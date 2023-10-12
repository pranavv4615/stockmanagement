using Microsoft.EntityFrameworkCore;
namespace StockOrderManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
