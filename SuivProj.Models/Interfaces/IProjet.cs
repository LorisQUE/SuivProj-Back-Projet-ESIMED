using System;
using System.Collections.Generic;
using System.Text;

namespace SuivProj.Models.Interfaces
{
    public interface IProjet
    {
        int Id { get; }
        string Nom { get; set; }
        IUtilisateur ChefProjet { get; set; }

        List<IExigence> Exigences { get; set; }
        List<ITache> Taches { get; set; }
        List<IJalon> Jalons { get; set; }

        DateTime DateDebut { get; set; }
        DateTime DateFinTheorique { get; set; }
        DateTime DateFinReelle { get; set; }
    }
}
