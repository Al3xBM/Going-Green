using FormGenerator.Data;
using Moq;
using System.Collections.Generic;

;

namespace FormGeneratorTests
{
    class FormGeneratorControllerTests
    {

        private readonly Mock<ProductList> mock;

        public FormGeneratorControllerTests()
        {
            mock = new Mock<ProductList>();
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
