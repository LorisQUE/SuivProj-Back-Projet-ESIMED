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
    public class JalonsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public JalonsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Jalons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jalon>>> GetJalon()
        {
            return await _context.Jalon.ToListAsync();
        }

        // GET: api/Jalons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jalon>> GetJalon(Guid id)
        {
            var jalon = await _context.Jalon.FindAsync(id);

            if (jalon == null)
            {
                return NotFound();
            }

            return jalon;
        }

        // PUT: api/Jalons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJalon(Guid id, Jalon jalon)
        {
            if (id != jalon.Id)
            {
                return BadRequest();
            }

            _context.Entry(jalon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JalonExists(id))
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

        // POST: api/Jalons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jalon>> PostJalon(Jalon jalon)
        {
            _context.Jalon.Add(jalon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJalon", new { id = jalon.Id }, jalon);
        }

        // DELETE: api/Jalons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJalon(Guid id)
        {
            var jalon = await _context.Jalon.FindAsync(id);
            if (jalon == null)
            {
                return NotFound();
            }

            _context.Jalon.Remove(jalon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JalonExists(Guid id)
        {
            return _context.Jalon.Any(e => e.Id == id);
        }
    }
}
