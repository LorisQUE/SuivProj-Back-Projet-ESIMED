using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuivProj.Dtos
{
    public class ExigenceDto
    {
        public Guid Id { get; init; }
        [Required]
        public string Description { get; set; } = String.Empty;
        [Required]
        public bool IsFonctionnel { get; set; }
        public string nonFonctionnel { get; set; } = String.Empty;
        public List<TacheDto> Taches { get; set; } = new();

        public Guid ProjetId { get; set; }
    }
}
