using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuivProj.Models.Classes;
using SuivProj.Models.DataAccess;
using SuivProj.Dtos;

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
        public async Task<ActionResult<IEnumerable<ExigenceDto>>> GetExigence()
        {
            return await _context.Exigence.Select(x => x.ToDto()).ToListAsync();
        }

        // GET: api/Exigences/Proj/5
        [HttpGet("Proj/{id}")]
        public async Task<ActionResult<IEnumerable<ExigenceDto>>> GetExigenceByProj(Guid id)
        {
            return await _context.Exigence.Where(x => x.ProjetId == id).Select(x => x.ToDto()).ToListAsync();
        }

        // GET: api/Exigences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExigenceDto>> GetExigence(Guid id)
        {
            var exigence = await _context.Exigence.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (exigence == null)
            {
                return NotFound();
            }

            return exigence.ToDto();
        }

        // PUT: api/Exigences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExigence(Guid id, ExigencePutDto ExigencePutDto)
        {
            var exigence = await _context.Exigence.FindAsync(id);

            if (exigence == null)
            {
                return BadRequest();
            }
            
            _context.Entry(exigence).State = EntityState.Modified;

            try
            {
                exigence.Description = ExigencePutDto.Description;
                exigence.IsFonctionnel = ExigencePutDto.IsFonctionnel;
                exigence.nonFonctionnel = ExigencePutDto.nonFonctionnel;
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
        public async Task<ActionResult<ExigenceDto>> PostExigence(ExigencePostDto ExigencePostDto)
        {
            Exigence exigence = new()
            {
                Description = ExigencePostDto.Description,
                IsFonctionnel = ExigencePostDto.IsFonctionnel,
                nonFonctionnel = ExigencePostDto.nonFonctionnel,
                ProjetId = ExigencePostDto.ProjetId
            };

            _context.Exigence.Add(exigence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExigence", new { id = exigence.Id }, exigence.ToDto());
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
