using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SuivProj.Models.Interfaces;

namespace SuivProj.Models.Classes
{
    public class Utilisateur
    {
        public Guid Id { get; init; }
        [Required]
        [MaxLength(3)]
        public string Trigramme { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Mail { get; set; }
    }
}
