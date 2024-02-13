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

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IRepository<Author> _repository;

        public AuthorsController(IRepository<Author> repo)
        {
            _repository = repo;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<IEnumerable<Author>> GetAuthors()
        {

            return await _repository.ListAll();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _repository.GetSingle(new AuthorByIdWithBooks(id));

            if (author == null) return NotFound();

            return author;
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.Id) return BadRequest();

            await _repository.Update(author);

            return NoContent();
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            await _repository.Insert(author);

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var Author = await _repository.GetById(id);
            if (Author == null) return NotFound();

            await _repository.Delete(Author);

            return NoContent();
        }
    }
}
