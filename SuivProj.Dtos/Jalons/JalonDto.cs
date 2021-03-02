using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuivProj.Dtos
{
    class JalonDto
    {
        public Guid Id { get; init; }
        [Required]
        public string Libelle { get; set; } = String.Empty;
        public List<TacheDto> Taches { get; } = new();
        public DateTime DateLivraisonPrevue { get; set; }
        public DateTime DateLivraisonReelle { get; set; }
        [Required]
        public UtilisateurDto Responsable { get; set; }
        public Guid ResponsableId { get; set; }
        public DateTime DateFinTheoriqueCalculer { get; set; }
        [Required]
        public ProjetDto Projet { get; set; }
        public Guid ProjetId { get; set; }
    }
}
