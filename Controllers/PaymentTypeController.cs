using System;
using System.Linq;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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