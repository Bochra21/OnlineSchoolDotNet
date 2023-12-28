﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineSchoolWebApp.Data;

#nullable disable

namespace OnlineSchoolWebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231228123126_Added All Models4")]
    partial class AddedAllModels4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.AnneeScolaire", b =>
                {
                    b.Property<int>("AnneeScolaireId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnneeScolaireId"));

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EtablissementId")
                        .HasColumnType("int");

                    b.HasKey("AnneeScolaireId");

                    b.HasIndex("EtablissementId");

                    b.ToTable("AnneeScolaire");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Classe", b =>
                {
                    b.Property<int>("ClasseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClasseId"));

                    b.Property<int?>("NiveauId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClasseId");

                    b.HasIndex("NiveauId");

                    b.ToTable("Classe");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Cours", b =>
                {
                    b.Property<int>("CoursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoursId"));

                    b.Property<int?>("EnseignantId")
                        .HasColumnType("int");

                    b.Property<string>("EnseignantId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("EtudiantId")
                        .HasColumnType("int");

                    b.Property<string>("EtudiantId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CoursId");

                    b.HasIndex("EnseignantId1");

                    b.HasIndex("EtudiantId1");

                    b.ToTable("Cours");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Departement", b =>
                {
                    b.Property<int>("DepartementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartementId"));

                    b.Property<int?>("AnneeId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartementId");

                    b.HasIndex("AnneeId");

                    b.ToTable("Departement");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Etablissement", b =>
                {
                    b.Property<int>("EtablissementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EtablissementId"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EtablissementId");

                    b.ToTable("Etablissement");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Niveau", b =>
                {
                    b.Property<int>("NiveauId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NiveauId"));

                    b.Property<int?>("DepartementId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NiveauId");

                    b.HasIndex("DepartementId");

                    b.ToTable("Niveau");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NoteId"));

                    b.Property<int?>("CoursId")
                        .HasColumnType("int");

                    b.Property<int?>("EtudiantId")
                        .HasColumnType("int");

                    b.Property<string>("EtudiantId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NoteDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("NoteValue")
                        .HasColumnType("real");

                    b.HasKey("NoteId");

                    b.HasIndex("CoursId");

                    b.HasIndex("EtudiantId1");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Enseignant", b =>
                {
                    b.HasBaseType("OnlineSchoolWebApp.Models.ApplicationUser");

                    b.Property<int?>("DepartementId")
                        .HasColumnType("int");

                    b.Property<int>("EnseignantId")
                        .HasColumnType("int");

                    b.HasIndex("DepartementId");

                    b.HasDiscriminator().HasValue("Enseignant");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Etudiant", b =>
                {
                    b.HasBaseType("OnlineSchoolWebApp.Models.ApplicationUser");

                    b.Property<int>("ClasseId")
                        .HasColumnType("int");

                    b.Property<int>("EtudiantId")
                        .HasColumnType("int");

                    b.HasIndex("ClasseId");

                    b.HasDiscriminator().HasValue("Etudiant");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.AnneeScolaire", b =>
                {
                    b.HasOne("OnlineSchoolWebApp.Models.Etablissement", "Etablissement")
                        .WithMany("AnneeScolaires")
                        .HasForeignKey("EtablissementId");

                    b.Navigation("Etablissement");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Classe", b =>
                {
                    b.HasOne("OnlineSchoolWebApp.Models.Niveau", "Niveau")
                        .WithMany("Classes")
                        .HasForeignKey("NiveauId");

                    b.Navigation("Niveau");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Cours", b =>
                {
                    b.HasOne("OnlineSchoolWebApp.Models.Enseignant", "Enseignant")
                        .WithMany("Cours")
                        .HasForeignKey("EnseignantId1");

                    b.HasOne("OnlineSchoolWebApp.Models.Etudiant", "Etudiant")
                        .WithMany("Cours")
                        .HasForeignKey("EtudiantId1");

                    b.Navigation("Enseignant");

                    b.Navigation("Etudiant");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Departement", b =>
                {
                    b.HasOne("OnlineSchoolWebApp.Models.AnneeScolaire", "Annee")
                        .WithMany("Departements")
                        .HasForeignKey("AnneeId");

                    b.Navigation("Annee");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Niveau", b =>
                {
                    b.HasOne("OnlineSchoolWebApp.Models.Departement", "Departement")
                        .WithMany("Niveaux")
                        .HasForeignKey("DepartementId");

                    b.Navigation("Departement");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Note", b =>
                {
                    b.HasOne("OnlineSchoolWebApp.Models.Cours", "Cours")
                        .WithMany("Notes")
                        .HasForeignKey("CoursId");

                    b.HasOne("OnlineSchoolWebApp.Models.Etudiant", "Etudiant")
                        .WithMany("Notes")
                        .HasForeignKey("EtudiantId1");

                    b.Navigation("Cours");

                    b.Navigation("Etudiant");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Enseignant", b =>
                {
                    b.HasOne("OnlineSchoolWebApp.Models.Departement", "Departement")
                        .WithMany()
                        .HasForeignKey("DepartementId");

                    b.Navigation("Departement");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Etudiant", b =>
                {
                    b.HasOne("OnlineSchoolWebApp.Models.Classe", "Classe")
                        .WithMany("Etudiants")
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classe");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.AnneeScolaire", b =>
                {
                    b.Navigation("Departements");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Classe", b =>
                {
                    b.Navigation("Etudiants");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Cours", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Departement", b =>
                {
                    b.Navigation("Niveaux");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Etablissement", b =>
                {
                    b.Navigation("AnneeScolaires");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Niveau", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Enseignant", b =>
                {
                    b.Navigation("Cours");
                });

            modelBuilder.Entity("OnlineSchoolWebApp.Models.Etudiant", b =>
                {
                    b.Navigation("Cours");

                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
