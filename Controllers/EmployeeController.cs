using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BangazonAPI.Controllers // Thursday, July 27 - Ollie
{
    [Produces("application/json")]
    [Route("employees")]
    [EnableCors("TeamOnly")]
    public class EmployeeController : Controller
    {
         private BangazonContext _context;
        public EmployeeController(BangazonContext ctx)
        {
            _context = ctx;
        }
        // GET api/values -- GET All Employees
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> employees = from employee in _context.Employee select employee;
            if(employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        // GET api/values/5 - Get A single Employee with ID from Route
        [HttpGet("{id}", Name = "GetEmployee")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Employee employee = _context.Employee.Single(e => e.EmployeeId == id);

                if (employee == null)
                {
                    return NotFound();
                }
                
                return Ok(employee);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }


        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employee.Add(employee);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(employee.EmployeeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }
        private bool EmployeeExists(int id)
        {
            return _context.Employee.Count(e => e.EmployeeId == id) > 0;
        }
    }
}