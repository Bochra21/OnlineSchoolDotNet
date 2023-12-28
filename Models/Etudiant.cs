using System;
using System.Collections.Generic;


namespace OnlineSchoolWebApp.Models
{
    public class Etudiant : ApplicationUser
    {

        // New property for Enseignant-specific ID
        public int EtudiantId { get; set; }

        // Other properties specific to Enseignant

        public virtual ICollection<Cours> Cours { get; set; } = new List<Cours>();

        public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

        public int ClasseId { get; set; }
        public virtual Classe? Classe { get; set; }
    }
}