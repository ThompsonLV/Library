using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Entities;
using Library.Infrastructure.Data;
using Library.API.Services;
using Library.Specifications;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IRepository<Admin> _repository;
        private IAuthenticationService AuthenticationService;
       

        public AdminsController(IRepository<Admin> repository, IAuthenticationService authenticationService)
        {
            _repository = repository;
            AuthenticationService = authenticationService;  
        }

      
        [HttpPost("login")]
        public async Task<IActionResult> Login(Admin admin)
        {
            var existingAdmin = await _repository.GetSingle(new AdminByUsernamePassword(admin.Email, admin.Password));

            if (existingAdmin == null)
                return new UnauthorizedResult();

            string accessToken = AuthenticationService.GenerateToken(existingAdmin);
            return new ObjectResult(new {
                existingAdmin.Id,
                existingAdmin.Email,
                access_token = accessToken
            });
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(Admin admin)
        {
            await _repository.Insert(admin);

            return CreatedAtAction("GetAdmin", new { id = admin.Id }, admin);
        }

        // GET: api/admin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            var admin = await _repository.GetById(id);

            if (admin == null) return NotFound();

            return admin;
        }

    }
}
