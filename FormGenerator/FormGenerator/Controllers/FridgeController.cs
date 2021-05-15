using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using FormGenerator.Data;
using FormGenerator.Entities;

namespace FormGenerator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        public IRepository<Fridge> _repository { get; }

        public FridgeController(IRepository<Fridge> reposotory)
        {
            _repository = reposotory;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fridge>> Get(Guid id)
        {
            return await _repository.GetById(id);
        }
    }
}
