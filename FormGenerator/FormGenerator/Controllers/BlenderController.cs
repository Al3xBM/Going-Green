using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using FormGenerator.Data;
using FormGenerator.Entities;

namespace FormGenerator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BlenderController : ControllerBase
    {
        public IRepository<Blender> _repository { get; }

        public BlenderController(IRepository<Blender> reposotory)
        {
            _repository = reposotory;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blender>> Get(Guid id)
        {
            return await _repository.GetById(id);
        }
    }
}
