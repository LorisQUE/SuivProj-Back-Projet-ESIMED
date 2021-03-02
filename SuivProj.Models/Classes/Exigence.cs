using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SuivProj.Models.Interfaces;

namespace SuivProj.Models.Classes
{
    public class Exigence
    {
        public Guid Id { get; init; }
        [Required]
        public string Description { get; set; } = String.Empty;
        [Required]
        public bool IsFonctionnel { get; set; }
        public string nonFonctionnel { get; set; } = String.Empty;
        public List<Tache> Taches { get; } = new();

        [Required]
        public Projet? Projet { get; set; }
        public Guid? ProjetId { get; set; }
    }
}
