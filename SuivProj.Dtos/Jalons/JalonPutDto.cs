using System;
using System.ComponentModel.DataAnnotations;

namespace SuivProj.Dtos
{
    public class JalonPutDto
    {
        public string Libelle { get; set; } = String.Empty;
        public Guid ResponsableId { get; set; }
        public Progression Progression { get; set; }
    }
}
