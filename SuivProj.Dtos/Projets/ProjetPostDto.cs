using System;
using System.ComponentModel.DataAnnotations;

namespace SuivProj.Dtos.Projets
{
    class ProjetPostDto
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public Guid ChefProjet { get; set; }
    }
}
