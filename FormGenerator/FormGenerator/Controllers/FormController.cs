using FormGenerator.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FormGenerator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        [HttpPost]
        public ActionResult<dynamic> GetFormFields(string applienceCategory)
        {
            var listOfProducts = (
                      from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                      from assemblyType in domainAssembly.GetTypes()
                      where typeof(BaseProduct).IsAssignableFrom(assemblyType)
                      select assemblyType
                  ).ToList();


            var something = listOfProducts[0];

            var instance = Activator.CreateInstance(listOfProducts[1]);

            return instance;
        }


    }
}
