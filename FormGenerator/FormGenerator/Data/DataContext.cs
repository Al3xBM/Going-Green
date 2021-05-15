using FormGenerator.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormGenerator.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DataContext() : base()
        {

        }
        public DbSet<Fridge> Fridges { get; set; }

        public DbSet<Television> Televisions { get; set; }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<Microwave> Microwaves { get; set; }

        public DbSet<VacuumCleaner> Vacuums { get; set; }

        public DbSet<Blender> Blenders { get; set; }

        public DbSet<BaseProduct> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
