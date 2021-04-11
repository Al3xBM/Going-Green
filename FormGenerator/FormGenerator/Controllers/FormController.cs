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
            var listOfProducts = ProductList.GetAllProductTypes();

            List<string> properties = new List<string>();

            foreach ( var type in listOfProducts )
            {
                if (type.Name == applienceCategory)
                {
                    foreach (var prop in type.GetProperties())
                    {
                        properties.Add(prop.Name);
                    }
                    break;
                }
            }

            properties.Remove("ID");
            properties.Remove("Type");

            return properties;
        }

        [HttpGet]
        public ActionResult<List<string>> GetAllProductTypes()
        {
            var listOfProducts = (
                      from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                      from assemblyType in domainAssembly.GetTypes()
                      where typeof(BaseProduct).IsAssignableFrom(assemblyType)
                      select assemblyType.Name
                  ).ToList();

            listOfProducts.Remove("BaseProduct");

            return listOfProducts;
        }
    }
}
