using FormGenerator.Data;
using Moq;
using System.Collections.Generic;
using Xunit;

;

namespace FormGeneratorTests
{
    public class FormGeneratorControllerTests
    {

        private readonly Mock<ProductList> mock;

        public FormGeneratorControllerTests()
        {
            mock = new Mock<ProductList>();
        }


        [Fact]
        public void test()
        {

        }

        public List<string> ProductListSeed()
        {
            var products = new List<string>()
             {
                    
            };
            return products;
        }
    }
}
