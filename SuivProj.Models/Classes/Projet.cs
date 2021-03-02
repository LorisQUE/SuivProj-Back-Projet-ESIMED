using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SuivProj.Models.Interfaces;

namespace SuivProj.Models.Classes
{
    public class Projet
    {
        public Guid Id { get; init; }
        [Required]
        [MaxLength(100)]
        public string Nom { get; set; } = String.Empty;
        [Required]
        public Utilisateur? ChefProjet { get; set; }
        public Guid? ChefProjetId { get; set; }
        public List<Exigence> Exigences { get; set; } = new();
        public List<Tache> Taches { get; set; } = new();
        public List<Jalon> Jalons { get; set; } = new();
        public DateTime DateDebut { get; set; }
        public DateTime DateFinTheorique { get; set; }
        public DateTime DateFinReelle { get; set; }
    }
}
