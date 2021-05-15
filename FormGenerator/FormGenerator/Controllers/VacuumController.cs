using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using FormGenerator.Data;
using FormGenerator.Entities;

namespace FormGenerator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VacuumController : ControllerBase
    {
        public IRepository<VacuumCleaner> _repository { get; }

        public VacuumController(IRepository<VacuumCleaner> reposotory)
        {
            _repository = reposotory;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VacuumCleaner>> Get(Guid id)
        {
            return await _repository.GetById(id);
        }
    }
}
