using FormGenerator.Data;
using System;
using FormGenerator.Entities;
using System.Linq;

namespace FormGenerator.Tests
{
    public class DatabaseInitializer
    {
        public static void Initilize(DataContext context)
        {
            if (context.Products.Any<BaseProduct>())
            {
                return;
            }
            else
            {
                Seed(context);
            }
        }

        private static void Seed(DataContext context)
        {
            var products = new[]
            {
                new BaseProduct
                {
                    ID = Guid.Parse("453b65b4-0287-4dfa-be3c-00c9ef7c2f2d"),
                    Brand = "Artic",
                    Series = "xv1",
                    Consumption = "123",
                    EnergyClass = "A++",
                    Colour = "white",
                    Weight = 15,
                    Type = "Fridge"
                },
                new BaseProduct
                {
                    ID = Guid.Parse("453b65b4-0287-4dfa-be3c-00c9ef7c2f1d"),
                    Brand = "Samsung",
                    Series = "rc1",
                    Consumption = "200",
                    EnergyClass = "A",
                    Colour = "Black",
                    Weight = 5,
                    Type = "Television"
                }
            };
            if (context.Products.Any())
                return;
            
            context.Products.AddRange(products);
            context.SaveChanges();

        }
    }
}
