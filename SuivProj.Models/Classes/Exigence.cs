using System;
using System.Collections.Generic;
using System.Text;
using SuivProj.Models.Interfaces;

namespace SuivProj.Models.Classes
{
    class Exigence : IExigence
    {
        public int Id { get; }

        public string Description { get; set; }
        public bool IsFonctionnel { get; set; }
        public string nonFonctionnel { get; set; }

        public List<ITache> Taches { get; }
    }
}
