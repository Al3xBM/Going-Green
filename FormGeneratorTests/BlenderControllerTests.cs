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
    public class BlenderControllerTests
    {
        private readonly IRepository<Blender> _repository;
        private readonly BlenderController blenderController;

        public BlenderControllerTests()
        {
            _repository = A.Fake<IRepository<Blender>>();
            blenderController = new BlenderController(_repository);
        }

        [Fact]
        public async void Given_AGuid_When_IdIsNotNull_Then_GetShouldReturnAProductOfTypeBlender()
        {
            var response = await blenderController.Get(Guid.Parse("453b65b4-0287-4dfa-be3c-00c9ef7c2f5d"));
            response.Should().BeOfType<ActionResult<Blender>>();

        }

    }
}
