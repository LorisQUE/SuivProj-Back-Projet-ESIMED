using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SuivProj.Models.Interfaces;

namespace SuivProj.Models.Classes
{
    public class Tache
    {
        public Guid Id { get; init; }
        [Required]
        public string Label { get; set; }
        public string Desc { get; set; }
        public List<Exigence> Exigences { get; }
        [Required]
        public DateTime DateDebutTheorique { get; set; }
        public DateTime DateDebutReelle { get; set; }
        public DateTime DateFinTheorique { get; set; }
        public DateTime DateFinReelle { get; set; }
        [Required]
        public float Charge { get; set; }
        public Jalon Jalon { get; set; }
        public Projet Projet { get; set; }
    }
}
