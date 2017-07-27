using System.Linq;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 * Class: ComputerController
 * Purpose: The ComputerController class is used to interact with the Computer table in the SQL database.
 * Author: Dilshod - Teamname-Teamname-Teamaname
 * Properties:
 *  Get(List): Returns all the computers in the database
    Get(Single): Returns an individual computer from the database
    Post: Adds new computer to the database
    Put: Updates specific computer information in the database
    Delete: Deletes specific computer from database
 */

namespace Bangazon.Controllers // Wendsday, July 26 - Dilshod
{
    [Produces("application/json")]
    [Route("computers")]
    [EnableCors("TeamOnly")]
    public class ComputerController : Controller
    {
        private BangazonContext _context;

        public ComputerController(BangazonContext ctx)
        {
            _context = ctx;
        }
        
        // GET / Computers
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> computers = from computer in _context.Computer select computer;

            if (computers == null)
            {
                return NotFound();
            }

            return Ok(computers);

        }

        // GET a single Computer
        [HttpGet("{id}", Name = "GetComputer")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Computer computer = _context.Computer.Single(m => m.ComputerId == id);

                if (computer == null)
                {
                    return NotFound();
                }
                
                return Ok(computer);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }


        }

        // POST / computer
        [HttpPost]
        public IActionResult Post([FromBody] Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Computer.Add(computer);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ComputerExists(computer.ComputerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetCustomer", new { id = computer.ComputerId }, computer);
        }

        // PUT /computers
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != computer.ComputerId)
            {
                return BadRequest();
            }

            _context.Entry(computer).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerExists(id))
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

        // DELETE /computer
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Computer computer = _context.Computer.Single(m => m.ComputerId == id);
            if (computer == null)
            {
                return NotFound();
            }

            _context.Computer.Remove(computer);
            _context.SaveChanges();

            return Ok(computer);
        }

        private bool ComputerExists(int id)
        {
            return _context.Computer.Count(e => e.ComputerId == id) > 0;
        }

    }
}
