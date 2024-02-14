using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Infrastructure.Data;
using SeedWork;
using Library.Specifications;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectorsController : ControllerBase
    {
        private readonly IRepository<Lector> _repository;
        private readonly IRepository<Address> _repoAddress;

        public LectorsController(IRepository<Lector> repo, IRepository<Address> repoAddress)
        {
            _repository = repo;
            _repoAddress = repoAddress;
        }

        // GET: api/Lectors
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IEnumerable<Lector>> GetLectors()
        {

            return await _repository.ListAll();
        }

        // GET: api/Lectors/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Lector>> GetLector(int id)
        {
            var lector = await _repository.GetSingle(new LectorByIdWithRentailsAddress(id));

            if (lector == null) return NotFound();

            return lector;
        }

        // PUT: api/Lectors/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutLector(int id, Lector Lector)
        {
            if (id != Lector.Id) return BadRequest();

            await _repository.Update(Lector);

            return NoContent();
        }

        // POST: api/Lectors
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Lector>> PostLector(Lector Lector)
        {
            var address = await _repoAddress.Insert(Lector.Address);
            Lector.Address = address;
            await _repository.Insert(Lector);

            return CreatedAtAction("GetLector", new { id = Lector.Id }, Lector);
        }

        // DELETE: api/Lectors/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteLector(int id)
        {
            var Lector = await _repository.GetById(id);
            if (Lector == null) return NotFound();

            await _repository.Delete(Lector);

            return NoContent();
        }
    }
}
