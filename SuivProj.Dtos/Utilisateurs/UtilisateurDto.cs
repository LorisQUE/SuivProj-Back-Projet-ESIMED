using System;

namespace SuivProj.Dtos
{
    public class UtilisateurDto
    {
        public Guid Id { get; set; }
        public string Trigramme { get; set; } = String.Empty;
        public string Prenom { get; set; } = String.Empty;
        public string Nom { get; set; } = String.Empty;
        public string Mail { get; set; } = String.Empty;
    }
}
