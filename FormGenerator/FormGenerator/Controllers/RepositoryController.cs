﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using FormGenerator.Entities;
using FormGenerator.Data;
using System;
using System.Reflection;
using System.Threading.Tasks;

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

        [HttpPost]
        public void Post([FromBody] Dictionary<string, string> product) // BaseProduct BaseProduct)
        {
            var listOfProducts =new ProductList().GetAllProductTypes();

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
                    break;
                }
            }

        }
    }
}