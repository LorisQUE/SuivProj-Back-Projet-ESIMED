using System;
using System.Collections.Generic;
using System.Text;
using SuivProj.Models.Interfaces;

namespace SuivProj.Models.Classes
{
    class Tache : ITache
    {
        public int Id { get; }
        public string Label { get; set; }
        public string Desc { get; set; }
        public List<IExigence> Exigences { get; }
        public DateTime DateDebutTheorique { get; set; }
        public DateTime DateDebutReelle { get; set; }
        public float Charge { get; set; }
        public IJalon Jalon { get; set; }
    }
}
