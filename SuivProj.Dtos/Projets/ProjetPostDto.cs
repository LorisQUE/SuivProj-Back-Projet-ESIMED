using System;
using System.ComponentModel.DataAnnotations;

namespace SuivProj.Dtos
{
    public class ProjetPostDto
    {
        public string Nom { get; set; }
        public Guid ChefProjetId { get; set; }
    }
}
