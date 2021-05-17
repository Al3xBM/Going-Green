using FakeItEasy;
using FluentAssertions;
using FormGenerator.Controllers;
using FormGenerator.Data;
using FormGenerator.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace FormGeneratorTests
{
    public class FridgeControllerTests
    {
        private readonly IRepository<Fridge> _repository;
        private readonly FridgeController fridgeController;

        public FridgeControllerTests()
        {
            _repository = A.Fake<IRepository<Fridge>>();
            fridgeController = new FridgeController(_repository);
        }

        [Fact]
        public async void Given_AGuid_When_IdIsNotNull_Then_GetShouldReturnAProductOfTypeFridge()
        {
            var response = await fridgeController.Get(Guid.Parse("453b65b4-0287-4dfa-be3c-00c9ef7c2f5d"));
            response.Should().BeOfType<ActionResult<Fridge>>();

        }

    }
}
