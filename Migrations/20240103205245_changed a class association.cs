using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSchoolWebApp.Migrations
{
    /// <inheritdoc />
    public partial class changedaclassassociation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cours_AspNetUsers_EtudiantId1",
                table: "Cours");

            migrationBuilder.DropForeignKey(
                name: "FK_Departement_AnneeScolaire_AnneeId",
                table: "Departement");

            migrationBuilder.DropForeignKey(
                name: "FK_Niveau_Departement_DepartementId",
                table: "Niveau");

            migrationBuilder.DropIndex(
                name: "IX_Cours_EtudiantId1",
                table: "Cours");

            migrationBuilder.DropColumn(
                name: "EtudiantId1",
                table: "Cours");

            migrationBuilder.AlterColumn<string>(
                name: "EtudiantId",
                table: "Cours",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClasseId",
                table: "Cours",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cours_ClasseId",
                table: "Cours",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_EtudiantId",
                table: "Cours",
                column: "EtudiantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cours_AspNetUsers_EtudiantId",
                table: "Cours",
                column: "EtudiantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cours_Classe_ClasseId",
                table: "Cours",
                column: "ClasseId",
                principalTable: "Classe",
                principalColumn: "ClasseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departement_AnneeScolaire_AnneeId",
                table: "Departement",
                column: "AnneeId",
                principalTable: "AnneeScolaire",
                principalColumn: "AnneeScolaireId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Niveau_Departement_DepartementId",
                table: "Niveau",
                column: "DepartementId",
                principalTable: "Departement",
                principalColumn: "DepartementId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cours_AspNetUsers_EtudiantId",
                table: "Cours");

            migrationBuilder.DropForeignKey(
                name: "FK_Cours_Classe_ClasseId",
                table: "Cours");

            migrationBuilder.DropForeignKey(
                name: "FK_Departement_AnneeScolaire_AnneeId",
                table: "Departement");

            migrationBuilder.DropForeignKey(
                name: "FK_Niveau_Departement_DepartementId",
                table: "Niveau");

            migrationBuilder.DropIndex(
                name: "IX_Cours_ClasseId",
                table: "Cours");

            migrationBuilder.DropIndex(
                name: "IX_Cours_EtudiantId",
                table: "Cours");

            migrationBuilder.DropColumn(
                name: "ClasseId",
                table: "Cours");

            migrationBuilder.AlterColumn<int>(
                name: "EtudiantId",
                table: "Cours",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EtudiantId1",
                table: "Cours",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cours_EtudiantId1",
                table: "Cours",
                column: "EtudiantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cours_AspNetUsers_EtudiantId1",
                table: "Cours",
                column: "EtudiantId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departement_AnneeScolaire_AnneeId",
                table: "Departement",
                column: "AnneeId",
                principalTable: "AnneeScolaire",
                principalColumn: "AnneeScolaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Niveau_Departement_DepartementId",
                table: "Niveau",
                column: "DepartementId",
                principalTable: "Departement",
                principalColumn: "DepartementId");
        }
    }
}
