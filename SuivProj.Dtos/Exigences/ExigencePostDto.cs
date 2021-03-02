using System;
using System.ComponentModel.DataAnnotations;

namespace SuivProj.Dtos
{
    public class ExigencePostDto
    {
        [Required]
        public string Description { get; set; } = String.Empty;
        [Required]
        public bool IsFonctionnel { get; set; }
        public string nonFonctionnel { get; set; } = String.Empty;
        [Required]
        public Guid ProjetId { get; set; }
    }
}
