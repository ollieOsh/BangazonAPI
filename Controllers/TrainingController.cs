using System;
using System.Linq;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 * Class: TrainingController
 * Purpose: The TrainingController class is used to interact with the Training table in the SQL database.
 * Author: Ollie - Teamname-Teamname-Teamaname
 * Properties:
 *  Get(List): Returns all the training programs in the database
    Get(Single): Returns an individual training program from the database
    Post: Adds new training program to the database
    Put: Updates specific training program information in the database
    Delete: Deletes specific training program from database (only if it hasn't started yet)
 */

namespace BangazonAPI.Controllers
{
    [Produces("application/json")]
    [Route("trainings")]
    [EnableCors("TeamOnly")]
    public class TrainingController : Controller
    {
        private BangazonContext _context;
        public TrainingController(BangazonContext ctx)
        {
            _context = ctx;
        }
        
        // GET /trainings Retrieve all training programs
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> trainings = from training in _context.Training select training;

            if (trainings == null)
            {
                return NotFound();
            }
            return Ok(trainings);
        }

        // GET /trainings/{id} / Retrieve single training
        [HttpGet("{id}", Name = "GetTraining")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Training training = _context.Training.Single(m => m.TrainingId == id);

                if (training == null)
                {
                    return NotFound();
                }
                
                return Ok(training);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST /trainings
        [HttpPost]
        public IActionResult Post([FromBody] Training training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Training.Add(training);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TrainingExists(training.TrainingId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetTraining", new { id = training.TrainingId }, training);
        }

        // PUT /trainings/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Training training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != training.TrainingId)
            {
                return BadRequest();
            }
            _context.Entry(training).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingExists(id))
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

        // DELETE /trainings/{id} -- ** only if start date is in the future **
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Training training = _context.Training.Single(m => m.TrainingId == id);
            if (training == null)
            {
                return NotFound();
            }
            DateTime today = DateTime.Today;
            var compareDate = DateTime.Compare(today, (DateTime)training.StartDate);
            if (compareDate < 0)
            {
                _context.Training.Remove(training);
                 _context.SaveChanges();

                return Ok(training);
            } else 
            {
                return BadRequest();
            }
            
        }
        private bool TrainingExists(int id)
        {
            return _context.Training.Count(e => e.TrainingId == id) > 0;
        }
    }
}
