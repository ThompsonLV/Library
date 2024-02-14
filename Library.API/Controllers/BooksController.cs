﻿using System;
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
    public class BooksController : ControllerBase
    {
        private readonly IRepository<Book> _repository;

        public BooksController(IRepository<Book> repo)
        {
            _repository = repo;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _repository.List(new BookListWithAuthorDomainRentails());
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _repository.GetSingle(new BookByIdWithAuthorDomainRentails(id));

            if (book == null) return NotFound();

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id) return BadRequest();

            await _repository.Update(book);

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            await _repository.Insert(book);

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _repository.GetById(id);
            if (book == null) return NotFound();

            await _repository.Delete(book);

            return NoContent();
        }

    }
}