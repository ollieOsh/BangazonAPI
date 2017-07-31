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
 * Class: ProductTypeController
 * Purpose: The ProductTypeController class is used to interact with the ProductType table in the SQL database.
 * Author: Joey - Teamname-Teamname-Teamaname
 * Properties:
 *  Get: Returns all the product types in the database
    Get(int id): Returns an individual product type from the database
    Post: Adds new product type to the database
    Put: Updates specific product type information in the database
    Delete: Deletes specific product type from database
 */

namespace BangazonAPI.Controllers // Wednesday, July 26 - Dilshod
{
    [Produces("application/json")]
    [Route("productType")]
    [EnableCors("TeamOnly")]

    public class ProductTypeController : Controller
    {
        private BangazonContext _context;

        public ProductTypeController(BangazonContext context)
        {
            _context = context;
        }

        // GET / Product All Product Types
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> productTypes = from productType in _context.ProductType select productType;

            if (productTypes == null)
            {
                return NotFound();
            }
            return Ok(productTypes);
        }

        // GET a single Product Type by its ID
        [HttpGet("{id}", Name = "GetSingleProductType")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ProductType productType = _context.ProductType.Single(m => m.ProductTypeId == id);

                if (productType == null)
                {
                    return NotFound();
                }
                
                return Ok(productType);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST a new Type of Product
        [HttpPost]
        public IActionResult Post([FromBody] ProductType productType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductType.Add(productType);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductTypeExists(productType.ProductTypeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleProductType", new { id = productType.ProductTypeId }, productType);
        }

        // PUT Edit Product Type
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductType productType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productType.ProductTypeId)
            {
                return BadRequest();
            }

            _context.Entry(productType).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeExists(id))
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

        // DELETE Product Type
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductType productType = _context.ProductType.Single(m => m.ProductTypeId == id);
            if (productType == null)
            {
                return NotFound();
            }

            _context.ProductType.Remove(productType);
            _context.SaveChanges();

            return Ok(productType);
        }

        private bool ProductTypeExists(int id)
        {
            return _context.ProductType.Count(e => e.ProductTypeId == id) > 0;
        }

    }
}