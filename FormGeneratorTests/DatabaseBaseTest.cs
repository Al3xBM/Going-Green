using FormGenerator.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace FormGenerator.Tests
{
    public class DatabaseBaseTest : IDisposable
    {
        protected readonly DataContext context;
        public DatabaseBaseTest()
        {
            var option = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase("Test").Options;
            context = new DataContext(option);
            context.Database.EnsureCreated();
            DatabaseInitializer.Initilize(context);
        }
        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

    }
}
