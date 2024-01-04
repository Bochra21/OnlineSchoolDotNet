using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSchoolWebApp.Migrations
{
    /// <inheritdoc />
    public partial class addedcascadeandonetomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnneeScolaire_Etablissement_EtablissementId",
                table: "AnneeScolaire");

            migrationBuilder.DropForeignKey(
                name: "FK_Classe_Niveau_NiveauId",
                table: "Classe");

            migrationBuilder.AddForeignKey(
                name: "FK_AnneeScolaire_Etablissement_EtablissementId",
                table: "AnneeScolaire",
                column: "EtablissementId",
                principalTable: "Etablissement",
                principalColumn: "EtablissementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classe_Niveau_NiveauId",
                table: "Classe",
                column: "NiveauId",
                principalTable: "Niveau",
                principalColumn: "NiveauId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnneeScolaire_Etablissement_EtablissementId",
                table: "AnneeScolaire");

            migrationBuilder.DropForeignKey(
                name: "FK_Classe_Niveau_NiveauId",
                table: "Classe");

            migrationBuilder.AddForeignKey(
                name: "FK_AnneeScolaire_Etablissement_EtablissementId",
                table: "AnneeScolaire",
                column: "EtablissementId",
                principalTable: "Etablissement",
                principalColumn: "EtablissementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classe_Niveau_NiveauId",
                table: "Classe",
                column: "NiveauId",
                principalTable: "Niveau",
                principalColumn: "NiveauId");
        }
    }
}
