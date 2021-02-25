using System;
using System.Collections.Generic;
using System.Text;

namespace SuivProj.Models.Interfaces
{
    public interface IExigence
    {
        int Id { get; }
        string Description { get; set; }
        bool IsFonctionnel { get; set; }
        string nonFonctionnel { get; set; }
        List<ITache> Taches { get; }
    }
}
