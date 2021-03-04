using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuivProj.Dtos;
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
        public async Task<ActionResult<IEnumerable<JalonDto>>> GetJalon()
        {
            return await _context.Jalon.Include(j => j.Taches).Select(x => x.ToDto()).ToListAsync();
        }

        // GET: api/Jalons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JalonDto>> GetJalon(Guid id)
        {
            var jalon = await _context.Jalon.Where(j => j.Id == id).Include(j => j.Taches).FirstOrDefaultAsync();

            if (jalon == null)
            {
                return NotFound();
            }

            return jalon.ToDto();
        }

        // PUT: api/Jalons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJalon(Guid id, JalonPutDto jalonDtoPut)
        {
            var Jalon = await _context.Jalon.FindAsync(id);
            var Responsable = await _context.Utilisateur.FindAsync(Jalon.ResponsableId);
            if (Jalon == null)
            {
                return BadRequest();
            }
            else if (Responsable == null)
            {
                return NotFound("Responsable non trouvé.");
            }

            _context.Entry(Jalon).State = EntityState.Modified;

            try
            {
                Jalon.Libelle = jalonDtoPut.Libelle;
                Jalon.Progression = jalonDtoPut.Progression;
                Jalon.ResponsableId = jalonDtoPut.ResponsableId;
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
        public async Task<ActionResult<JalonDto>> PostJalon(JalonPostDto jalonPostDto)
        {
            var Projet = await _context.Projet.FindAsync(jalonPostDto.ProjetId);
            var Responsable = await _context.Utilisateur.FindAsync(jalonPostDto.ResponsableId);
            if (Projet == null)
            {
                return NotFound("Projet non trouvé.");
            }
            else if(Responsable == null)
            {
                return NotFound("Utilisateur non trouvé.");
            }

            Jalon jalon = new()
            {
                Libelle = jalonPostDto.Libelle,
                ResponsableId = jalonPostDto.ResponsableId,
                ProjetId = jalonPostDto.ProjetId
            };

            _context.Jalon.Add(jalon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJalon", new { id = jalon.Id }, jalon.ToDto());
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
