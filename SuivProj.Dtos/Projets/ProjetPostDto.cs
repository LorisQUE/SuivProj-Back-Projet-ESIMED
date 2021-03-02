using System;
using System.ComponentModel.DataAnnotations;

namespace SuivProj.Dtos.Projets
{
    public class ProjetPostDto
    {
        public string Nom { get; set; }
        public Guid ChefProjet { get; set; }
    }
}
