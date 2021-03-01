using System;
using System.Collections.Generic;
using System.Text;

namespace SuivProj.Models.Interfaces
{
    public interface IUtilisateur
    {
        int Id { get; }
        string Trigramme { get; set; }
        string Prenom { get; set; }
        string Nom { get; set; }
        string Mail { get; set; }

        //IENumerable Role a implémenter
    }
}
