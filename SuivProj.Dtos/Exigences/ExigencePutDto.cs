using System;

namespace SuivProj.Dtos
{
    public class ExigencePutDto
    {
        public string Description { get; set; } = String.Empty;
        public bool IsFonctionnel { get; set; }
        public string nonFonctionnel { get; set; } = String.Empty;
    }
}
