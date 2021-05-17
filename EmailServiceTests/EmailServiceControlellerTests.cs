using EmailService.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace EmailServiceTests
{
    public class EmailServiceControlellerTests
    {
        private readonly EmailServiceController emailService;
        public EmailServiceControlellerTests()
        {
            emailService = new EmailServiceController();
        }
        [Fact]
        public void ShoudThrowException()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
         
            Assert.Throws<ArgumentNullException>(() => emailService.Post(data));
        }
    }
}
