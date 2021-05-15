using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using FormGenerator.Data;
using FormGenerator.Entities;

namespace FormGenerator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TelevisionController : ControllerBase
    {
        public IRepository<Television> _repository { get; }

        public TelevisionController(IRepository<Television> reposotory)
        {
            _repository = reposotory;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Television>> Get(Guid id)
        {
            return await _repository.GetById(id);
        }
    }
}
