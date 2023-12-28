using System;
using System.Collections.Generic;

namespace OnlineSchoolWebApp.Models
{
    public class Departement
    {
        public int DepartementId { get; set; }

        public string Nom { get; set; } = null!;

        public int? AnneeId { get; set; }

        public virtual ICollection<Niveau> Niveaux { get; set; } = new List<Niveau>();

        public virtual AnneeScolaire? Annee { get; set; }
    }
}