using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuivProj.Dtos
{
    class TacheDto
    {
        public Guid Id { get; init; }
        [Required]
        [MaxLength(50)]
        public string Label { get; set; } = String.Empty;
        [MaxLength(1000)]
        public string Desc { get; set; }
        public List<ExigenceDto> Exigences { get; } = new();
        [Required]
        public DateTime DateDebutTheorique { get; set; }
        public DateTime DateDebutReelle { get; set; }
        public DateTime DateFinTheorique { get; set; }
        public DateTime DateFinReelle { get; set; }
        [Required]
        public float Charge { get; set; }
        public JalonDto Jalon { get; set; }
        public Guid? JalonId { get; set; }
        public ProjetDto Projet { get; set; }
        public Guid? ProjetId { get; set; }
    }
}
