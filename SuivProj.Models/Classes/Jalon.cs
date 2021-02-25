using System;
using System.Collections.Generic;
using System.Text;
using SuivProj.Models.Interfaces;

namespace SuivProj.Models.Classes
{
    class Jalon : IJalon
    {
        public int id { get; }

        public string libelle { get; set; }

        public List<ITache> Taches { get; }

        public bool isLivrable { get; set; }
        public DateTime DateLivraisonPrevue { get; set; }
        public DateTime DateLivraisonReelle { get; set; }
        public IUser User { get; set; }
        public DateTime DateTheoriqueCalculer { get; set; }
        public IProjet Projet { get; set; }
    }
}
