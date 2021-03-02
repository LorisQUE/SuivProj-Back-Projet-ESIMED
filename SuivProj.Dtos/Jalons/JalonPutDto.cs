using System;
using System.ComponentModel.DataAnnotations;

namespace SuivProj.Dtos
{
    class JalonPutDto
    {
        [Required]
        public string Libelle { get; set; } = String.Empty;
        [Required]
        public Guid ResponsableId { get; set; }
    }
}
