using FormGenerator.Data;
using FormGenerator.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FormGenerator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        [HttpPost]
        public ActionResult<List<string>> GetFormFields([FromBody]string applienceCategory)
        { 
            return ProductList.GetProductProperties(applienceCategory);
        }

        [HttpGet]
        public ActionResult<List<string>> GetAllProductTypes()
        {
            var listOfProducts = ProductList.GetAllProductNames();

            listOfProducts.Remove("BaseProduct");

            return listOfProducts;
        }
    }
}
