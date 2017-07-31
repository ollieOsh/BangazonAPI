using System;
using System.Linq;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 * Class: PaymentTypeController
 * Purpose: The PaymentTypeController class is used to interact with the PaymentType table in the SQL database.
 * Author: Joey - Teamname-Teamname-Teamaname
 * Properties:
 *  Get: Returns all the payment types in the database
    Get(int id): Returns an individual payment type from the database
    Post: Adds new payment type to the database
    Put: Updates specific payment type information in the database
    Delete: Deletes specific payment type from database
 */

namespace BangazonAPI.Controllers
{
    [Produces("application/json")]
    [Route("paymentType")]
    [EnableCors("TeamOnly")]
    public class PaymentTypeController : Controller
    {
        private BangazonContext _context;

        public PaymentTypeController(BangazonContext ctx)
        {
            _context = ctx;
        }
        //GET / all payment type
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> paymentTypes = from paymentType in _context.PaymentType select paymentType;
            if(paymentTypes == null)
            {
                return NotFound();
            }
                return Ok(paymentTypes);
        } 

        //GET / single payment type
        [HttpGet("{id}", Name="GetSinglePaymentType")]
        public IActionResult Get([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PaymentType paymentType = _context.PaymentType.Single(i => i.PaymentTypeId == id);
                {
                    if(paymentType == null)
                        return NotFound();
                }
                    return Ok(paymentType);
            } catch(System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }
        //POST single payment type
        [HttpPost]
        public IActionResult Post([FromBody] PaymentType newPaymentType)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                _context.PaymentType.Add(newPaymentType);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if(PaymentTypeAlreadyExists(newPaymentType.PaymentTypeId))
                {
                    return new  StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSinglePaymentType", new {id = newPaymentType.PaymentTypeId}, newPaymentType);
        }

        // PUT a single paymentType
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != paymentType.PaymentTypeId)
            {
                return BadRequest();
            }
            _context.Entry(paymentType).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypeAlreadyExists(id))
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

        //DELETE single payment type
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PaymentType paymentType = _context.PaymentType.Single(l => l.PaymentTypeId == id);
            {
                if(paymentType == null)
                {
                    return NotFound();
                }
                _context.PaymentType.Remove(paymentType);
                _context.SaveChanges();

                return Ok(paymentType);
            }
        }
        private bool PaymentTypeAlreadyExists(int paymentTypeId)
        {
            return _context.PaymentType.Count(i => i.PaymentTypeId == paymentTypeId) > 0;
        }
    }
}