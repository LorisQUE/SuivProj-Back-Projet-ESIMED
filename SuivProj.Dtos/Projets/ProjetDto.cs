using System;
using System.Collections.Generic;

namespace SuivProj.Dtos
{
    public class ProjetDto
    {
        public Guid Id { get; init; }
        public string Nom { get; set; }
        public UtilisateurDto ChefProjet { get; set; }
        public List<ExigenceDto> Exigences { get; set; }
        public List<TacheDto> Taches { get; set; }
        public List<JalonDto> Jalons { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFinTheorique { get; set; }
        public DateTime DateFinReelle { get; set; }
    }
}
