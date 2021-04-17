using FakeItEasy;
using FluentAssertions;
using FormGenerator.Data;
using FormGenerator.Entities;
using System;
using System.Linq;
using Xunit;

namespace FormGenerator.Tests
{
    public class RepositoryTests: DatabaseBaseTest
    {
        private readonly Repository<BaseProduct> repository;
        private readonly BaseProduct newBaseProduct;

        public RepositoryTests()
        {
            repository = new Repository<BaseProduct>(context);
            newBaseProduct = new BaseProduct
            {

                ID = Guid.Parse("453b65b4-0287-4dfa-be3c-00c9ef7c2f5d"),
                Brand = "Philips",
                Series = "abc",
                Consumption = "50",
                EnergyClass = "-A",
                Colour = "Red",
                Weight = 5,
                Type = "Television"

            };
            context2 = A.Fake<DataContext>();
            repository2 = new Repository<BaseProduct>(context2);
        }

        [Fact]
        public async void Given_NewProduct_WhenProductIsNotNull_Then_CreateAsynsShouldReturnANewProduct()
        {
            var result = await repository2.CreateAsync(newBaseProduct);

            result.Should().BeOfType<BaseProduct>();

        }
        [Fact]
        public async void Given_NewProduct_WhenProductIsNull_Then_CreateAsyncShouldReturnException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await repository2.CreateAsync(null));
        }
        [Fact]
        public async void Given_AProduct_WhenProductIsNotNull_Then_DeleteAsynsShouldReturnTheProduct()
        {
            var product =
                  new BaseProduct
                  {
                      ID = Guid.Parse("453b65b4-0287-4dfa-be3c-00c9ef7c2f3d"),
                      Brand = "Artic",
                      Series = "xv1",
                      Consumption = "123",
                      EnergyClass = "A++",
                      Colour = "white",
                      Weight = 15,
                      Type = "Fridge"
                  };
            var result = await repository2.DeleteAsync(product);

            result.Should().BeOfType<BaseProduct>();
        }
        [Fact]
        public async void Given_AProduct_WhenProductIsNull_Then_DeleteAsyncShouldReturnException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await repository.DeleteAsync(null));
        }
        [Fact]
        public async void Given_AProduct_WhenProductIsNull_Then_DeleteAsyncShouldDeleteTheProduct()
        {
            var products1 = repository.GetAll();

            await repository.CreateAsync(newBaseProduct);
            await repository.DeleteAsync(newBaseProduct);

            var product2 = repository.GetAll();

            products1.Should().Equals(product2);


        }
        [Fact]
        public async void Given_AProduct_WhenProductIsNotNull_Then_UpdateAsynsShouldReturnTheProduct()
        {
            var product =
                new BaseProduct
                {
                    ID = Guid.Parse("453b65b4-0287-4dfa-be3c-00c9ef7c2f4d"),
                    Brand = "Samsung",
                    Series = "rc1",
                    Consumption = "200",
                    EnergyClass = "A",
                    Colour = "Black",
                    Weight = 5,
                    Type = "Television"
                };
            var result = await repository2.UpdateAsync(product);

            result.Should().BeOfType<BaseProduct>();
        }
        [Fact]
        public async void Given_AProduct_WhenProductIsNull_Then_UpdateAsyncShouldReturnException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await repository.UpdateAsync(null));
        }
        [Fact]
        public async void Given_AGuid_WhenGuidIsNotEmpty_Then_GetByIdShouldReturnAProduct()
        {
            var result = await repository.GetById(Guid.Parse("453b65b4-0287-4dfa-be3c-00c9ef7c2f2d"));

            result.Should().BeOfType<BaseProduct>();

        }
        [Fact]
        public async void Given_AGuid_WhenGuisIsEmpty_Then_GetByIdShouldReturnException()
        {
            await Assert.ThrowsAsync<ArgumentException>(async () => await repository.GetById(Guid.Empty));
        }
        [Fact] 
        void GetAllShouldReturnAllProducts()
        {
            var results =  repository.GetAll().ToList();

            Assert.Equal(2, results.Count());
        }
        private readonly DataContext context2;
        private readonly Repository<BaseProduct> repository2;

    }
}
