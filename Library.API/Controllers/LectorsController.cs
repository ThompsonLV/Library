using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Entities;
using Library.Infrastructure.Data;
using Library.Specifications;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectorsController : ControllerBase
    {
        private readonly IRepository<Lector> _repository;

        public LectorsController(IRepository<Lector> repo)
        {
            _repository = repo;
        }

        // GET: api/Lectors
        [HttpGet]
        public async Task<IEnumerable<Lector>> GetLectors()
        {

            return await _repository.ListAll();
        }

        // GET: api/Lectors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lector>> GetLector(int id)
        {
            var Lector = await _repository.GetSingle(new LectorById(id));

            if (Lector == null) return NotFound();

            return Lector;
        }

        // PUT: api/Lectors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLector(int id, Lector Lector)
        {
            if (id != Lector.Id) return BadRequest();

            await _repository.Update(Lector);

            return NoContent();
        }

        // POST: api/Lectors
        [HttpPost]
        public async Task<ActionResult<Lector>> PostLector(Lector Lector)
        {
            await _repository.Insert(Lector);

            return CreatedAtAction("GetLector", new { id = Lector.Id }, Lector);
        }

        // DELETE: api/Lectors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLector(int id)
        {
            var Lector = await _repository.GetById(id);
            if (Lector == null) return NotFound();

            await _repository.Delete(Lector);

            return NoContent();
        }
    }
}
