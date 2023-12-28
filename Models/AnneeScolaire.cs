using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineSchoolWebApp.Models
{
    public class AnneeScolaire
    {
        public int AnneeScolaireId { get; set; }

        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }


        public int? EtablissementId { get; set; }

    

        public virtual ICollection<Departement> Departements { get; set; } = new List<Departement>();

        public virtual Etablissement? Etablissement { get; set; }
    }
}