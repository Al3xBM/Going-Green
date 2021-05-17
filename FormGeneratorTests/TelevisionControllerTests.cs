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
    public class TelevisionControllerTests
    {
        private readonly IRepository<Television> _repository;
        private readonly TelevisionController TelevisionController;

        public TelevisionControllerTests()
        {
            _repository = A.Fake<IRepository<Television>>();
            TelevisionController = new TelevisionController(_repository);
        }

        [Fact]
        public async void Given_AGuid_When_IdIsNotNull_Then_GetShouldReturnAProductOfTypeTelevision()
        {
            var response = await TelevisionController.Get(Guid.Parse("453b65b4-0287-4dfa-be3c-00c9ef7c2f5d"));
            response.Should().BeOfType<ActionResult<Television>>();

        }

    }
}