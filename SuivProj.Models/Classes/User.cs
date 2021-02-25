using System;
using System.Collections.Generic;
using System.Text;
using SuivProj.Models.Interfaces;

namespace SuivProj.Models.Classes
{
    class User : IUser
    {
        public int Id { get; }
        public string Trigramme { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Mail { get; set; }
    }
}
