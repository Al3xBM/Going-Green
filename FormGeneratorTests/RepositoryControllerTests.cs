using FormGenerator.Data;
using FormGenerator.Entities;
using System;
using Moq;
using Xunit;
using System.Collections.Generic;
using FormGenerator.Controllers;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FormGenerator.Tests
{
    public class RepositoryControllerTests
    {
        private readonly Mock<IRepository<BaseProduct>> mock;
        private readonly RepositoryController repositoryController;
        private readonly BaseProduct newBaseProduct;
        
       

        public RepositoryControllerTests()
        {



            mock = new Mock<IRepository<BaseProduct>>();
            newBaseProduct = new BaseProduct
            {

                ID = Guid.Parse("453b65b4-0287-4dfa-be3c-00c9ef7c2f7d"),
                Brand = "Philips",
                Series = "abc",
                Consumption = "50",
                EnergyClass = "-A",
                Colour = "Red",
                Weight = 5,
                Type = "Television"

            };


        }


        [Fact]
        void GetAllShouldReturnAllProducts()
        {
            mock.Setup(moq => moq.GetAll()).Returns(ProductSeed);

            var controller = new RepositoryController(mock.Object);

            var response = controller.GetAll();

            Assert.Equal(2, response.Value.Count());
        }
        [Fact]
        public void Given_AGuid_GetbyId_ThenShouldReturnAProduct()
        {
            var controller = new RepositoryController(A.Fake<Repository<BaseProduct>>());
                
            var result = controller.Get(Guid.Parse("453b65b4-0287-4dfa-be3c-00c9ef7c2f7d"));

            result.Result.Should().BeOfType<ActionResult<BaseProduct>>();
        }
        public List<BaseProduct> ProductSeed()
        {
            var products = new List<BaseProduct>()
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
            return products;
        }
    }
}
