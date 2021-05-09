using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using FormGenerator.Entities;
using FormGenerator.Data;
using System;
using System.Reflection;
using System.Threading.Tasks;
using PricePredictionML.Model;

namespace FormGenerator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        public IRepository<BaseProduct> _repository { get; }

        public RepositoryController(IRepository<BaseProduct> reposotory)
        {
            _repository = reposotory;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BaseProduct>> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseProduct>> Get(Guid id)
        {
            return await _repository.GetById(id);
        }

        [HttpGet("category/{category}")]
        public ActionResult<IEnumerable<BaseProduct>> GetByCategory(string category)
        {
            return _repository.GetAll().Where(p => p.Type == category).ToList();
        }

        [HttpPost]
        public float Post([FromBody] Dictionary<string, string> product) // BaseProduct BaseProduct)
        {
            var listOfProducts =new ProductList().GetAllProductTypes();

            ModelInput modelInput = new ModelInput();

            PropertyInfo[] properties = typeof(ModelInput).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (product.ContainsKey(property.Name))
                {
                    var val = new ProductList().CastPropertyValue(property, product[property.Name]);
                    property.SetValue(modelInput, val);
                }
                else
                {
                    property.SetValue(modelInput, null);
                }
                
            }

            var pricePrediction = ConsumeModel.Predict(modelInput);

            Console.WriteLine(pricePrediction.Score);

            foreach (var type in listOfProducts)
            {
                if (type.Name == product["Type"])
                {
                    var instance = Activator.CreateInstance(type);
                    
                    foreach(var prop in product)
                    {
                        PropertyInfo propInfo = type.GetProperty(prop.Key);
                        var val =new ProductList().CastPropertyValue(propInfo, prop.Value);
                        propInfo.SetValue(instance, val);
                    }

                    _repository.CreateAsync((BaseProduct)instance);
                    return pricePrediction.Score;
                }
            }
            return 0;
        }
    }
}