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
        public string Libelle { get; set; }
        public List<Tache> Taches { get; }
        public DateTime DateLivraisonPrevue { get; set; }
        public DateTime DateLivraisonReelle { get; set; }
        [Required]
        public Utilisateur Utilisateur { get; set; }
        public DateTime DateFinTheoriqueCalculer { get; set; }
        [Required]
        public Projet Projet { get; set; }

        public bool IsLivrable()
        {
            return true;
        }
    }
}
