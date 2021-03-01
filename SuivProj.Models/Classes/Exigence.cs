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
        public string Description { get; set; }
        [Required]
        public bool IsFonctionnel { get; set; }
        public string nonFonctionnel { get; set; }
        public List<Tache> Taches { get; }

        [Required]
        public Projet Projet { get; set; }
    }
}
