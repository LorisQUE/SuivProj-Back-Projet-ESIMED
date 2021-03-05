using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuivProj.Dtos;
using SuivProj.Models.Classes;

namespace SuivProj
{
    public static class Extension
    {
        public static ExigenceDto ToDto(this Exigence pExigence)
        {
            return new ExigenceDto
            {
                Id = pExigence.Id,
                Description = pExigence.Description,
                IsFonctionnel = pExigence.IsFonctionnel,
                nonFonctionnel = pExigence.nonFonctionnel,
                Taches = pExigence.Taches.Select(x => x.ToDto()).ToList(),
                ProjetId = (Guid)pExigence.ProjetId
            };
        }
        public static ProjetDto ToDto(this Projet pProjet)
        {
            return new ProjetDto
            {
                Id = pProjet.Id,
                Nom = pProjet.Nom,
                ChefProjetId = (Guid)pProjet.ChefProjetId,
                ChefProjet = pProjet.ChefProjet.ToDto(),
                Exigences = pProjet.Exigences.Select(x => x.ToDto()).ToList(),
                Taches = pProjet.Taches.Select(x => x.ToDto()).ToList(),
                Jalons = pProjet.Jalons.Select(x => x.ToDto()).ToList(),
                DateDebut = pProjet.DateDebut,
                DateFinTheorique = pProjet.DateFinTheorique,
                DateFinReelle = pProjet.DateFinReelle,
            };
        }
        public static TacheDto ToDto(this Tache pTache)
        {
            return new TacheDto
            {
                Id = pTache.Id,
                Label = pTache.Label,
                Desc = pTache.Desc,
                Exigences = pTache.Exigences.Select(x => x.ToDto()).ToList(),
                DateDebutTheorique = pTache.DateDebutTheorique,
                DateDebutReelle = pTache.DateDebutReelle,
                DateFinTheorique = pTache.DateFinTheorique,
                DateFinReelle = pTache.DateFinReelle,
                Charge = pTache.Charge,
                JalonId = (Guid)pTache.JalonId,
                ProjetId = (Guid)pTache.ProjetId
            };
        }
        public static JalonDto ToDto(this Jalon pJalon)
        {
            return new JalonDto
            {
                Id = pJalon.Id,
                Libelle = pJalon.Libelle,
                Taches = pJalon.Taches.Select(x => x.ToDto()).ToList(),
                DateLivraisonPrevue = pJalon.DateLivraisonPrevue,
                DateLivraisonReelle = pJalon.DateLivraisonReelle,
                DateFinTheoriqueCalculer = pJalon.DateFinTheoriqueCalculer,
                ResponsableId = pJalon.ResponsableId,
                ProjetId = pJalon.ProjetId,
                Progression = pJalon.Progression
            };
        }
        public static UtilisateurDto ToDto(this Utilisateur pUtilisateur)
        {
            return new UtilisateurDto
            {
                Id = pUtilisateur.Id,
                Trigramme = pUtilisateur.Trigramme,
                Nom = pUtilisateur.Nom,
                Prenom = pUtilisateur.Prenom,
                Mail = pUtilisateur.Mail
            };
        }
    }
}
