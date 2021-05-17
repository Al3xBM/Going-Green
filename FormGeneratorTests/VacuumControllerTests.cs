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
    public class VacuumControllerTests
    {
        private readonly IRepository<VacuumCleaner> _repository;
        private readonly VacuumController VacuumController;

        public VacuumControllerTests()
        {
            _repository = A.Fake<IRepository<VacuumCleaner>>();
            VacuumController = new VacuumController(_repository);
        }

        [Fact]
        public async void Given_AGuid_When_IdIsNotNull_Then_GetShouldReturnAProductOfTypeVacuum()
        {
            var response = await VacuumController.Get(Guid.Parse("453b65b4-0287-4dfa-be3c-00c9ef7c2f5d"));
            response.Should().BeOfType<ActionResult<VacuumCleaner>>();

        }

    }
}