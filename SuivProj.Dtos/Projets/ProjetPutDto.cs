using System;

namespace SuivProj.Dtos.Projets
{
    public class ProjetPutDto
    {
        public string Nom { get; set; }
        public Guid ChefProjet { get; set; }
    }
}
