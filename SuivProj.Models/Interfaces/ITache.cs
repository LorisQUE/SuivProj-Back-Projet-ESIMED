using System;
using System.Collections.Generic;
using System.Text;

namespace SuivProj.Models.Interfaces
{
    public interface ITache
    {
        int Id { get; }
        string Label { get; set; }
        string Desc { get; set; }
        List<IExigence> Exigences { get; }
        DateTime DateDebutTheorique { get; set; }
        DateTime DateDebutReelle { get; set; }
        float Charge { get; set; }
        
        IJalon Jalon { get; set; }
    }
}
