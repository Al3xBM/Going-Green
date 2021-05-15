using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using FormGenerator.Data;
using FormGenerator.Entities;

namespace FormGenerator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MicrowaveController : ControllerBase
    {
        public IRepository<Microwave> _repository { get; }

        public MicrowaveController(IRepository<Microwave> reposotory)
        {
            _repository = reposotory;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Microwave>> Get(Guid id)
        {
            return await _repository.GetById(id);
        }
    }
}
