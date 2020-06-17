using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramAssessment.Entities.Models;

namespace ProgramAssessment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntitiesController : ControllerBase
    {
        private readonly iContext _context;

        public EntitiesController(iContext context)
        {
            _context = context;
        }

        // GET: api/Jobs
        [HttpGet]
        public IEnumerable<ProgramAssessments> GetJobs()
        {
            return _context.ProgramAssessments
                .Include("Files");

        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntities([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var entities = await _context.ProgramAssessments
                .Include("Files").FirstOrDefaultAsync(x => x.Id == id);

                if (entities == null)
                {
                    return NotFound();
                }

                //var result = Json(new { Result = jobs });

                return Ok(entities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public Jobs GetJobs([FromRoute] long id)
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}

        //    try
        //    {
        //        var jobs = _context.Jobs
        //        .Include("JobsFiles").FirstOrDefault(x => x.AdId == id);

        //        //if (jobs == null)
        //        //{
        //        //    return NotFound();
        //        //}

        //        //var result = Json(new { Result = jobs });

        //        return jobs;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }            
        //}

        // PUT: api/Jobs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobs([FromRoute] int id, [FromBody] ProgramAssessments prg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prg.Id)
            {
                return BadRequest();
            }

            _context.Entry(prg).State = EntityState.Modified;

            foreach (Files child in prg.Files)
            {
                _context.Entry(child).State = child.Id == 0 ? EntityState.Added : EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramAssessmentsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Jobs
        [HttpPost]
        public async Task<IActionResult> PostJobs([FromBody] ProgramAssessments prg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProgramAssessments.Add(prg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgramAssessments", new { id = prg.Id }, prg);
        }

        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var jobs = await _context.Jobs.FindAsync(id);

            var p = await _context.ProgramAssessments
                            .Include("Files").FirstOrDefaultAsync(x => x.Id == id);

            if (p == null)
            {
                return NotFound();
            }

            try
            {
                foreach (var child in p.Files.ToList())
                    _context.Files.Remove(child);

                _context.ProgramAssessments.Remove(p);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(p);
        }

        private bool ProgramAssessmentsExists(int id)
        {
            return _context.ProgramAssessments.Any(e => e.Id == id);
        }
    }
}

