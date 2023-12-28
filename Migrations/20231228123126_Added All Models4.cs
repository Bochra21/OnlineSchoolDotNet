using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSchoolWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedAllModels4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClasseId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartementId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnseignantId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EtudiantId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cours",
                columns: table => new
                {
                    CoursId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EtudiantId = table.Column<int>(type: "int", nullable: true),
                    EnseignantId = table.Column<int>(type: "int", nullable: true),
                    EtudiantId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EnseignantId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cours", x => x.CoursId);
                    table.ForeignKey(
                        name: "FK_Cours_AspNetUsers_EnseignantId1",
                        column: x => x.EnseignantId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cours_AspNetUsers_EtudiantId1",
                        column: x => x.EtudiantId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Etablissement",
                columns: table => new
                {
                    EtablissementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etablissement", x => x.EtablissementId);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteValue = table.Column<float>(type: "real", nullable: false),
                    NoteDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EtudiantId = table.Column<int>(type: "int", nullable: true),
                    EtudiantId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CoursId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Note_AspNetUsers_EtudiantId1",
                        column: x => x.EtudiantId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Note_Cours_CoursId",
                        column: x => x.CoursId,
                        principalTable: "Cours",
                        principalColumn: "CoursId");
                });

            migrationBuilder.CreateTable(
                name: "AnneeScolaire",
                columns: table => new
                {
                    AnneeScolaireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EtablissementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnneeScolaire", x => x.AnneeScolaireId);
                    table.ForeignKey(
                        name: "FK_AnneeScolaire_Etablissement_EtablissementId",
                        column: x => x.EtablissementId,
                        principalTable: "Etablissement",
                        principalColumn: "EtablissementId");
                });

            migrationBuilder.CreateTable(
                name: "Departement",
                columns: table => new
                {
                    DepartementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnneeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departement", x => x.DepartementId);
                    table.ForeignKey(
                        name: "FK_Departement_AnneeScolaire_AnneeId",
                        column: x => x.AnneeId,
                        principalTable: "AnneeScolaire",
                        principalColumn: "AnneeScolaireId");
                });

            migrationBuilder.CreateTable(
                name: "Niveau",
                columns: table => new
                {
                    NiveauId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveau", x => x.NiveauId);
                    table.ForeignKey(
                        name: "FK_Niveau_Departement_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departement",
                        principalColumn: "DepartementId");
                });

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    ClasseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NiveauId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.ClasseId);
                    table.ForeignKey(
                        name: "FK_Classe_Niveau_NiveauId",
                        column: x => x.NiveauId,
                        principalTable: "Niveau",
                        principalColumn: "NiveauId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClasseId",
                table: "AspNetUsers",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartementId",
                table: "AspNetUsers",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_AnneeScolaire_EtablissementId",
                table: "AnneeScolaire",
                column: "EtablissementId");

            migrationBuilder.CreateIndex(
                name: "IX_Classe_NiveauId",
                table: "Classe",
                column: "NiveauId");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_EnseignantId1",
                table: "Cours",
                column: "EnseignantId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_EtudiantId1",
                table: "Cours",
                column: "EtudiantId1");

            migrationBuilder.CreateIndex(
                name: "IX_Departement_AnneeId",
                table: "Departement",
                column: "AnneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Niveau_DepartementId",
                table: "Niveau",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_CoursId",
                table: "Note",
                column: "CoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_EtudiantId1",
                table: "Note",
                column: "EtudiantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Classe_ClasseId",
                table: "AspNetUsers",
                column: "ClasseId",
                principalTable: "Classe",
                principalColumn: "ClasseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departement_DepartementId",
                table: "AspNetUsers",
                column: "DepartementId",
                principalTable: "Departement",
                principalColumn: "DepartementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Classe_ClasseId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departement_DepartementId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Classe");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Niveau");

            migrationBuilder.DropTable(
                name: "Cours");

            migrationBuilder.DropTable(
                name: "Departement");

            migrationBuilder.DropTable(
                name: "AnneeScolaire");

            migrationBuilder.DropTable(
                name: "Etablissement");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClasseId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartementId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClasseId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartementId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EnseignantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EtudiantId",
                table: "AspNetUsers");
        }
    }
}
