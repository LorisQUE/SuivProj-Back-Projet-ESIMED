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
        public string Trigramme { get; set; } = String.Empty;
        [Required]
        [MaxLength(100)]
        public string Prenom { get; set; } = String.Empty;
        [Required]
        [MaxLength(100)]
        public string Nom { get; set; } = String.Empty;
        [Required]
        [MaxLength(100)]
        public string Mail { get; set; } = String.Empty;
    }
}
