using System;
using System.Collections.Generic;

namespace OnlineSchoolWebApp.Models
{
    public class Cours
    {
        public int CoursId { get; set; }

        public string Nom { get; set; } = null!;

        public int? ClasseId { get; set; }
        public int? EnseignantId { get; set; }

        public virtual Classe? Classe { get; set; }
        public virtual Enseignant? Enseignant { get; set; }

        public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
