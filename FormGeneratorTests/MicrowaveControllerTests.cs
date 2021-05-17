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
    public class MicrowaveControllerTests
    {
        private readonly IRepository<Microwave> _repository;
        private readonly MicrowaveController microwaveController;

        public MicrowaveControllerTests()
        {
            _repository = A.Fake<IRepository<Microwave>>();
            microwaveController = new MicrowaveController(_repository);
        }

        [Fact]
        public async void Given_AGuid_When_IdIsNotNull_Then_GetShouldReturnAProductOfTypeMicrowave()
        {
            var response = await microwaveController.Get(Guid.Parse("453b65b4-0287-4dfa-be3c-00c9ef7c2f5d"));
            response.Should().BeOfType<ActionResult<Microwave>>();

        }

    }
}
