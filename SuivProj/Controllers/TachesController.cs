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
    public class TachesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public TachesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Taches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TacheDto>>> GetTache()
        {
            return await _context.Tache.Include(t => t.Exigences).Select(t => t.ToDto()).ToListAsync();
        }

        // GET: api/Taches/Proj/5
        [HttpGet("Proj/{id}")]
        public async Task<ActionResult<IEnumerable<TacheDto>>> GetTachesByProj(Guid id)
        {
            return await _context.Tache.Include(t => t.Exigences).Where(t => t.ProjetId == id).Select(t => t.ToDto()).ToListAsync();
        }

        // GET: api/Taches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TacheDto>> GetTache(Guid id)
        {
            var tache = await _context.Tache.FindAsync(id);

            if (tache == null)
            {
                return NotFound();
            }

            return tache.ToDto();
        }

        // PUT: api/Taches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTache(Guid id, TachePutDto tachePutDto)
        {
            var tache = await _context.Tache.FindAsync(id);
            var jalon = await _context.Jalon.FindAsync(tachePutDto.JalonId);
            var proprietaire = await _context.Utilisateur.FindAsync(tachePutDto.ProprietaireId);

            var exigences = new List<Exigence>();

            foreach(var exigenceId in tachePutDto.Exigences)
            {
                var exigence = await _context.Exigence.FindAsync(exigenceId);
                exigences.Add(exigence);
            }

            if (tache == null)
            {
                return BadRequest();
            }

            _context.Entry(tache).State = EntityState.Modified;
            try
            {
                tache.Label = tachePutDto.Label;
                tache.Desc = tachePutDto.Desc;
                tache.Charge = tachePutDto.Charge;
                tache.DateDebutTheorique = tachePutDto.DateDebutTheorique;
                tache.Exigences = exigences;
                tache.JalonId = jalon.Id;
                tache.ProprietaireId = tachePutDto.ProprietaireId;

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
        public async Task<ActionResult<TacheDto>> PostTache(TachePostDto tachePostDto)
        {
            var jalon = await _context.Jalon.FindAsync(tachePostDto.JalonId);
            var projet = await _context.Projet.FindAsync(tachePostDto.ProjetId);
            var proprietaire = await _context.Utilisateur.FindAsync(tachePostDto.ProprietaireId);

            var exigences = new List<Exigence>();

            foreach(var exigenceId in tachePostDto.Exigences)
            {
                var exigence = await _context.Exigence.FindAsync(exigenceId);
                exigences.Add(exigence);
            }

            if(projet == null)
            {
                return BadRequest();
            }

            Tache tache = new()
            {
                Label = tachePostDto.Label,
                Desc = tachePostDto.Desc,
                Charge = tachePostDto.Charge,
                DateDebutTheorique = tachePostDto.DateDebutTheorique,
                ProjetId = tachePostDto.ProjetId,
                JalonId = tachePostDto.JalonId,
                ProprietaireId = tachePostDto.ProprietaireId,
                Exigences = exigences,
            };

            _context.Tache.Add(tache);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTache", new { id = tache.Id }, tache.ToDto());
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
