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
    public class RentalsController : ControllerBase
    {
        private readonly IRepository<Rental> _repository;

        public RentalsController(IRepository<Rental> repo)
        {
            _repository = repo;
        }

        // GET: api/Rentals
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IEnumerable<Rental>> GetRentals()
        {

            return await _repository.List(new RentalListWithBookLector());
        }
   

        // GET: api/Rentals/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Rental>> GetRental(int id)
        {
            var rental = await _repository.GetSingle(new RentalByIdWithBookLector(id));

            if (rental == null) return NotFound();

            return rental;
        }

        // PUT: api/Rentals/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutRental(int id, Rental rental)
        {
            if (id != rental.Id) return BadRequest();

            await _repository.Update(rental);

            return NoContent();
        }

        // POST: api/Rentals
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Rental>> PostRental(Rental rental)
        {   
            rental.RentailDate = DateTime.Now;
            await _repository.Insert(rental);

            return CreatedAtAction("GetRental", new { id = rental.Id }, rental);
        }
        // POST: api/Rentals
        [HttpPut("returnBook/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Rental>> ReturnBook(int id, Rental rental)
        {

            if (id != rental.Id) return BadRequest();
            rental.ReturnDate = DateTime.Now;
            await _repository.Update(rental);

            var rentalUpdated = await _repository.GetSingle(new RentalByIdWithBookLector(id));
            return rentalUpdated;
        }

        // DELETE: api/Rentals/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteRental(int id)
        {
            var rental = await _repository.GetById(id);
            if (rental == null) return NotFound();

            await _repository.Delete(rental);

            return NoContent();
        }
    }
}
