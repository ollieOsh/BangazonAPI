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

/**
 * Class: ComputerController
 * Purpose: The ComputerController class is used to interact with the Computer table in the SQL database.
 * Author: Dilshod - Teamname-Teamname-Teamaname
 * Properties:
 *  Get: Returns all the computers in the database
    Get(int id): Returns an individual computer from the database
    Post: Adds new computer to the database
    Put: Updates specific computer information in the database
    Delete: Deletes specific computer from database
 */

namespace BangazonAPI.Controllers // Wednesday, July 26 - Dilshod
{
    [Produces("application/json")]
    [Route("products")]
    [EnableCors("TeamOnly")]
    public class ProductController : Controller
    {
        private BangazonContext _context;
        public ProductController(BangazonContext ctx)
        {
            _context = ctx;
        }
        // GET api/values -- GET All Products
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> products = from product in _context.Product select product;
            if(products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        // GET api/values/5 - Get A single Product with ID from Route
        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Product product = _context.Product.Single(p => p.ProductId == id);

                if (product == null)
                {
                    return NotFound();
                }
                
                return Ok(product);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }


        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Product.Add(product);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.ProductId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetProduct", new { id = product.ProductId }, product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = _context.Product.Single(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Count(e => e.ProductId == id) > 0;
        }
    }
}
