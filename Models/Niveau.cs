using System;
using System.Collections.Generic;

namespace OnlineSchoolWebApp.Models
{
    public class Niveau
    {
        public int NiveauId { get; set; }
        public string Nom { get; set; } = null!;

        public int? DepartementId { get; set; }

        public virtual Departement? Departement { get; set; }

        public virtual ICollection<Classe> Classes { get; set; } = new List<Classe>();

    }
}
