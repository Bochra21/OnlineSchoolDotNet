using System;
using System.Collections.Generic;

namespace OnlineSchoolWebApp.Models
{
    public class Note
    {

        public int NoteId { get; set; }

        public float NoteValue { get; set; }

        public string NoteDesc { get; set; }

        public int? EtudiantId { get; set; }
        public virtual Etudiant? Etudiant { get; set; } = null;

        public int? CoursId { get; set; }
        public virtual Cours? Cours { get; set; } = null;


    }
}
