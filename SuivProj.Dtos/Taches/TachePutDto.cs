using System;
using System.Collections.Generic;

namespace SuivProj.Dtos
{
    public class TachePutDto
    {
        public string Label { get; set; } = String.Empty;
        public string Desc { get; set; } = String.Empty;
        public List<Guid> Exigences { get; } = new();
        public DateTime DateDebutTheorique { get; set; }
        public float Charge { get; set; } = 1f;
        public Guid JalonId { get; set; }
    }
}
