using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SuivProj.Models.Classes;

namespace SuivProj.Dtos
{
    public class JalonDto
    {
        public Guid Id { get; init; }
        [Required]
        public string Libelle { get; set; } = String.Empty;
        public List<TacheDto> Taches { get; set; } = new();
        public DateTime? DateLivraisonPrevue { get; set; }
        public DateTime? DateLivraisonReelle { get; set; }
        public DateTime? DateFinTheoriqueCalculer { get; set; }
        [Required]
        public Guid ResponsableId { get; set; }
        [Required]
        public Guid ProjetId { get; set; }
        public Progression Progression { get; set; }
    }
}
