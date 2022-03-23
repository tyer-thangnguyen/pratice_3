using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice_3.Data;
using Practice_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TenantsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsTenant = _context.Tenants.ToList();
            return Ok(dsTenant);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var tenant = _context.Tenants.SingleOrDefault(te => te.Id == id);
            if(tenant != null)
            {
                return Ok(tenant);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateNew(TenantModel model)
        {
            try
            {
                var tenant = new Tenant
                {
                    Name = model.Name
                };
                _context.Add(tenant);
                _context.SaveChanges();
                return Ok(tenant);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTenantById(Guid id, TenantModel model)
        {
            var tenant = _context.Tenants.SingleOrDefault(te => te.Id == id);
            if (tenant != null)
            {
                tenant.Name = model.Name;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
