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
        public string Nom { get; set; }
        [Required]
        public Utilisateur ChefProjet { get; set; }
        public List<Exigence> Exigences { get; set; }
        public List<Tache> Taches { get; set; }
        public List<Jalon> Jalons { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFinTheorique { get; set; }
        public DateTime DateFinReelle { get; set; }
    }
}
