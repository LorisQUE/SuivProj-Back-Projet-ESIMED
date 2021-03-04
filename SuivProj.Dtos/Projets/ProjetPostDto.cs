using System;
using System.ComponentModel.DataAnnotations;

namespace SuivProj.Dtos
{
    public class ProjetPostDto
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public Guid ChefProjetId { get; set; }
    }
}
