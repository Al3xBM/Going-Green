using System;
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
        public DbSet<BaseProduct> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
