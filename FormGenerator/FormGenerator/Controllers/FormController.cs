using FormGenerator.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FormGenerator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        [HttpPost]
        public ActionResult<List<string>> GetFormFields([FromBody]Dictionary<string,string> applienceCategory)
        { 
            return new ProductList().GetProductProperties(applienceCategory["Type"]);
        }

        [HttpGet]
        public ActionResult<List<string>> GetAllProductTypes()
        {
            var listOfProducts =new ProductList().GetAllProductNames();

            listOfProducts.Remove("BaseProduct");

            return listOfProducts;
        }
    }
}
