using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using FormGenerator.Entities;
using FormGenerator.Data;

namespace FormGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        public IRepository<BaseProduct> _repository { get; }

        public RepositoryController(IRepository<BaseProduct> reposotory)
        {
            _repository = reposotory;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BaseProduct>> Get()
        {
            return _repository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<BaseProduct> Get(int id)
        {
            return this._repository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] BaseProduct BaseProduct)
        {
            _repository.Create(BaseProduct);
        }
    }
}
