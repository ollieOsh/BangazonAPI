using System.Linq;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 * Class: DepartmentController
 * Purpose: The DepartmentController class is used to interact with the Department table in the SQL database.
 * Author: Dilshod - Teamname-Teamname-Teamaname
 * Properties:
 *  Get(List): Returns all the departments in the database
    Get(Single): Returns an individual department from the database
    Post: Adds new department to the database
    Put: Updates specific department information in the database
 */

namespace Bangazon.Controllers // Wendsday, July 26 - Dilshod
{
    [Produces("application/json")]
    [Route("departments")]
    [EnableCors("TeamOnly")]
    public class DepartmentController : Controller
    {
        private BangazonContext _context;

        public DepartmentController(BangazonContext ctx)
        {
            _context = ctx;
        }
        
        // GET / Departments
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> departments = from department in _context.Department select department;

            if (departments == null)
            {
                return NotFound();
            }

            return Ok(departments);

        }

        // GET a single Department
        [HttpGet("{id}", Name = "GetDeparment")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Department department = _context.Department.Single(m => m.DepartmentId == id);

                if (department == null)
                {
                    return NotFound();
                }
                
                return Ok(department);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }


        }

        // POST / Department
        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Department.Add(department);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DepartmentExists(department.DepartmentId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetDeparment", new { id = department.DepartmentId }, department);
        }

        // PUT /Department
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        private bool DepartmentExists(int id)
        {
            return _context.Department.Count(e => e.DepartmentId == id) > 0;
        }

    }
}