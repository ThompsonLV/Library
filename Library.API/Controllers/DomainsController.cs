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

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainsController : ControllerBase
    {
        private readonly IRepository<Domain> _repository;

        public DomainsController(IRepository<Domain> repo)
        {
            _repository = repo;
        }

        // GET: api/Domains
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IEnumerable<Domain>> GetDomains()
        {   

            return await _repository.List(new DomainListWithBooks());
        }

        // GET: api/Domains/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Domain>> GetDomain(int id)
        {
            var domain = await _repository.GetSingle(new DomainByIdWithBooks(id));

            if (domain == null) return NotFound();
            
            return domain;
        }

        // PUT: api/Domains/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutDomain(int id, Domain domain)
        {
            if (id != domain.Id) return BadRequest();

            await _repository.Update(domain);

            return NoContent();
        }

        // POST: api/Domains
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Domain>> PostDomain(Domain domain)
        {
            await _repository.Insert(domain);

            return CreatedAtAction("GetDomain", new { id = domain.Id }, domain);
        }

        // DELETE: api/Domains/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteDomain(int id)
        {
            var domain = await _repository.GetById(id);
            if (domain == null) return NotFound();

            await _repository.Delete(domain);

            return NoContent();
        }
    }
}
