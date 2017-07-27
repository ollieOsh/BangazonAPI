using System.Linq;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 * Class: OrderController
 * Purpose: The OrderController class is used to interact with the Order table in the SQL database.
 * Author: Kathy - Teamname-Teamname-Teamaname
 * Properties:
 *  Get(List): Returns all the orders in the database
    Get(Single): Returns an individual order from the database
    Post: Adds new order to the database
    Put: Updates specific order information in the database
    Delete: Deletes specific order from database
 */

namespace BangazonAPI.Controllers
{
    [Produces("application/json")]
    [Route("orders")]
    [EnableCors("TeamOnly")]
    public class OrderController : Controller
    {
        private BangazonContext _context;
        public OrderController(BangazonContext ctx)
        {
            _context = ctx;
        }
        
        // GET /Retrieve all orders
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> orders = from order in _context.Order select order;

            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        // GET /orders/5 / Retrieve single order
        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Order order = _context.Order.Single(m => m.OrderId == id);

                if (order == null)
                {
                    return NotFound();
                }
                
                return Ok(order);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST /orders
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Order.Add(order);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(order.OrderId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetOrder", new { id = order.OrderId }, order);
        }

        // PUT /orders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != order.OrderId)
            {
                return BadRequest();
            }
            _context.Entry(order).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // DELETE /orders/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Order order = _context.Order.Single(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            _context.Order.Remove(order);
            _context.SaveChanges();

            return Ok(order);
        }
        private bool OrderExists(int id)
        {
            return _context.Order.Count(e => e.OrderId == id) > 0;
        }
    }
}
