using System;
using System.Collections.Generic;

namespace OnlineSchoolWebApp.Models
{
    public class Etablissement
    {
        public int EtablissementId { get; set; }

        public string Nom { get; set; } = null!;

        public string Adresse { get; set; } = null!;

        public virtual ICollection<AnneeScolaire> AnneeScolaires { get; set; } = new List<AnneeScolaire>();
    }
}