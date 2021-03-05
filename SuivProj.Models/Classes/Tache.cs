using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SuivProj.Models.Interfaces;

namespace SuivProj.Models.Classes
{
    public class Tache
    {
        public Guid Id { get; init; }
        [Required]
        [MaxLength(50)]
        public string Label { get; set; }
        [MaxLength(1000)]
        public string? Desc { get; set; } = String.Empty;
        public List<Exigence>? Exigences { get; set; }
        [Required]
        public DateTime DateDebutTheorique { get; set; }
        public DateTime DateDebutReelle { get; set; }
        public DateTime DateFinTheorique { get; set; }
        public DateTime DateFinReelle { get; set; }
        [Required]
        public float Charge { get; set; }
        public Guid? JalonId { get; set; }
        public Guid ProjetId { get; set; }
        public Guid ProprietaireId { get; set; }
    }
}
