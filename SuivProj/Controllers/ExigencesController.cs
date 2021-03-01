using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuivProj.Models.Classes;
using SuivProj.Models.DataAccess;

namespace SuivProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExigencesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public ExigencesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Exigences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exigence>>> GetExigence()
        {
            return await _context.Exigence.ToListAsync();
        }

        // GET: api/Exigences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exigence>> GetExigence(Guid id)
        {
            var exigence = await _context.Exigence.FindAsync(id);

            if (exigence == null)
            {
                return NotFound();
            }

            return exigence;
        }

        // PUT: api/Exigences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExigence(Guid id, Exigence exigence)
        {
            if (id != exigence.Id)
            {
                return BadRequest();
            }

            _context.Entry(exigence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExigenceExists(id))
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

        // POST: api/Exigences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exigence>> PostExigence(Exigence exigence)
        {
            _context.Exigence.Add(exigence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExigence", new { id = exigence.Id }, exigence);
        }

        // DELETE: api/Exigences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExigence(Guid id)
        {
            var exigence = await _context.Exigence.FindAsync(id);
            if (exigence == null)
            {
                return NotFound();
            }

            _context.Exigence.Remove(exigence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExigenceExists(Guid id)
        {
            return _context.Exigence.Any(e => e.Id == id);
        }
    }
}
