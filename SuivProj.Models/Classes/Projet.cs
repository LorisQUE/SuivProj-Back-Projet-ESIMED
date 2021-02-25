using System;
using System.Collections.Generic;
using System.Text;
using SuivProj.Models.Interfaces;

namespace SuivProj.Models.Classes
{
    class Projet : IProjet
    {
        public int Id { get; }

        public string Nom { get; set; }
        public IUser ChefProjet { get; set; }
        public List<IExigence> Exigences { get; set; }
        public List<ITache> Taches { get; set; }
        public List<IJalon> Jalons { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFinTheorique { get; set; }
        public DateTime DateFinReelle { get; set; }
    }
}
