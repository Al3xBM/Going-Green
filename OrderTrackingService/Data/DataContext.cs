using OrderTrackingService.Entities;
using Microsoft.EntityFrameworkCore;

namespace OrderTrackingService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DataContext() : base()
        {

        }
        public DbSet<OrderInfo> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
