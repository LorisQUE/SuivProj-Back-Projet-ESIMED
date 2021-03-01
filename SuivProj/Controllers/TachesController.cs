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
    public class TachesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public TachesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Taches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tache>>> GetTache()
        {
            return await _context.Tache.ToListAsync();
        }

        // GET: api/Taches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tache>> GetTache(Guid id)
        {
            var tache = await _context.Tache.FindAsync(id);

            if (tache == null)
            {
                return NotFound();
            }

            return tache;
        }

        // PUT: api/Taches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTache(Guid id, Tache tache)
        {
            if (id != tache.Id)
            {
                return BadRequest();
            }

            _context.Entry(tache).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TacheExists(id))
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

        // POST: api/Taches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tache>> PostTache(Tache tache)
        {
            _context.Tache.Add(tache);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTache", new { id = tache.Id }, tache);
        }

        // DELETE: api/Taches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTache(Guid id)
        {
            var tache = await _context.Tache.FindAsync(id);
            if (tache == null)
            {
                return NotFound();
            }

            _context.Tache.Remove(tache);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TacheExists(Guid id)
        {
            return _context.Tache.Any(e => e.Id == id);
        }
    }
}
