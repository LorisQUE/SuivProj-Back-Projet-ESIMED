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
    public class ProjetsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public ProjetsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Projets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjetDto>>> GetProjet()
        {
            return await _context.Projet.Include(p => p.ChefProjet).Include(p => p.Exigences).Include(p => p.Jalons).Select(x => x.ToDto()).ToListAsync();
        }

        // GET: api/Projets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjetDto>> GetProjet(Guid id)
        {
            var projet = await _context.Projet.Where(p => p.Id == id).Include(p => p.ChefProjet).Include(p => p.Exigences).Include(p => p.Jalons).FirstOrDefaultAsync();

            if (projet == null)
            {
                return NotFound();
            }

            return projet.ToDto();
        }

        // PUT: api/Projets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjet(Guid id, ProjetPutDto projetPutDto)
        {
            var projet = await _context.Projet.FindAsync(id);
            var chefProjet = await _context.Utilisateur.FindAsync(projetPutDto.ChefProjetId);
            if (projet == null)
            {
                return BadRequest();
            }
            else if(chefProjet == null)
            {
                return NotFound("Chef de Projet non trouvé.");
            }
            _context.Entry(projet).State = EntityState.Modified;
            try
            {
                projet.Nom = projetPutDto.Nom;
                projet.ChefProjetId = projetPutDto.ChefProjetId;
                projet.ChefProjet = chefProjet;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetExists(id))
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

        // POST: api/Projets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjetDto>> PostProjet(ProjetPostDto projetPostDto)
        {
            var ChefProjet = await _context.Utilisateur.FindAsync(projetPostDto.ChefProjetId);

            if(ChefProjet == null)
            {
                return NotFound("Chef de projet non trouvé.");
            }

            Projet projet = new()
            {
                Nom = projetPostDto.Nom,
                ChefProjetId = projetPostDto.ChefProjetId,
                ChefProjet = ChefProjet,
            };

            _context.Projet.Add(projet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjet", new { id = projet.Id }, projet.ToDto());
        }

        // DELETE: api/Projets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjet(Guid id)
        {
            var projet = await _context.Projet.FindAsync(id);
            if (projet == null)
            {
                return NotFound();
            }

            _context.Projet.Remove(projet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjetExists(Guid id)
        {
            return _context.Projet.Any(e => e.Id == id);
        }
    }
}
