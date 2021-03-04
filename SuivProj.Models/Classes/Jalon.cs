using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SuivProj.Models.Interfaces;

namespace SuivProj.Models.Classes
{
    public class Jalon
    {
        public Guid Id { get; init; }
        [Required]
        public string Libelle { get; set; } = String.Empty;
        public List<Tache> Taches { get; set; } = new();
        public DateTime? DateLivraisonPrevue { get; set; }
        public DateTime? DateLivraisonReelle { get; set; }
        [Required]
        public Guid? ResponsableId { get; set; }
        public DateTime? DateFinTheoriqueCalculer { get; set; }
        [Required]
        public Guid ProjetId { get; set; }
        public Progression Progression { get; set; } = Progression.Creation;

        public bool IsLivrable()
        {
            return true;
        }
    }

    public enum Progression
    {
        Creation = 0,
        EnCours = 50,
        Fini = 100
    }
}
