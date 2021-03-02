using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuivProj.Dtos
{
    class TachePostDto
    {
        [Required]
        [MaxLength(50)]
        public string Label { get; set; } = String.Empty;
        [MaxLength(1000)]
        public string Desc { get; set; } = String.Empty;
        public List<Guid> Exigences { get; } = new();
        [Required]
        public DateTime DateDebutTheorique { get; set; }
        [Required]
        public float Charge { get; set; } = 1f;
        public Guid JalonId { get; set; }
        [Required]
        public Guid ProjetId { get; set; }
    }
}
