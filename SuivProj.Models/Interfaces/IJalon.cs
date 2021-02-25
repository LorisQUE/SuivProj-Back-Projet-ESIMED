using System;
using System.Collections.Generic;

namespace SuivProj.Models.Interfaces
{
    public interface IJalon
    {
        int Id { get; }
        string Libelle { get; set; }
        List<ITache> Taches { get; }
        DateTime DateLivraisonPrevue { get; set; }
        DateTime DateLivraisonReelle { get; set; }
        IUser User { get; set; }
        DateTime DateTheoriqueCalculer { get; set; }
        IProjet Projet { get; set; }
        bool IsLivrable();
    }
}