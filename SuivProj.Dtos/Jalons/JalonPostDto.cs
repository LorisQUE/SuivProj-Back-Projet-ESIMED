using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuivProj.Dtos
{
    class JalonPostDto
    {
        [Required]
        public string Libelle { get; set; } = String.Empty;
        [Required]
        public Guid? ResponsableId { get; set; }
        [Required]
        public Guid ProjetId { get; set; }
    }
}
