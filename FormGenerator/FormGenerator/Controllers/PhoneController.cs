using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using FormGenerator.Data;
using FormGenerator.Entities;

namespace FormGenerator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        public IRepository<Phone> _repository { get; }

        public PhoneController(IRepository<Phone> reposotory)
        {
            _repository = reposotory;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Phone>> Get(Guid id)
        {
            return await _repository.GetById(id);
        }
    }
}
