using System;
using System.Collections.Generic;



namespace OnlineSchoolWebApp.Models
{
    public class Classe
    {

        public int ClasseId { get; set; }
        public string Nom { get; set; } = null!;

        public int? NiveauId { get; set; }

        public virtual Niveau? Niveau { get; set; }

        public virtual ICollection<Etudiant> Etudiants { get; set; } = new List<Etudiant>();



    }



}
