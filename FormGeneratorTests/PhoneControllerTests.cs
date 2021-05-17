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
    public class PhoneControllerTests
    {
        private readonly IRepository<Phone> _repository;
        private readonly PhoneController phoneController;

        public PhoneControllerTests()
        {
            _repository = A.Fake <IRepository<Phone>>();
            phoneController = new PhoneController(_repository);
        }

        [Fact]
        public async void Given_AGuid_When_IdIsNotNull_Then_GetShouldReturnAProductOfTypePhone()
        {
            var response = await phoneController.Get(Guid.Parse("453b65b4-0287-4dfa-be3c-00c9ef7c2f5d"));
            response.Should().BeOfType<ActionResult<Phone>>();
            
        }
  
    }
}
