using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineSchoolWebApp.Models;

namespace OnlineSchoolWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<AnneeScolaire> AnneeScolaire { get;set; }
        public DbSet<Classe> Classe { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<Departement> Departement { get; set; }

        public DbSet<Enseignant> Enseignant { get; set; } 

        public DbSet<Etudiant> Etudiant { get; set; }

        public DbSet<Etablissement> Etablissement { get; set;}
        public DbSet<Niveau> Niveau { get; set; }
        public DbSet<Note> Note { get; set; }


    }
}
