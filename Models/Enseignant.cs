using System;
using System.Collections.Generic;

namespace OnlineSchoolWebApp.Models
{
    public class Enseignant : ApplicationUser
    {

        // New property for Enseignant-specific ID
        public int EnseignantId { get; set; }

        // Other properties specific to Enseignant

        public virtual ICollection<Cours> Cours { get; set; } = new List<Cours>();

        public int? DepartementId { get; set; }

        public virtual Departement? Departement { get; set; }

    

    }
}