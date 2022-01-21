using Microsoft.EntityFrameworkCore.Migrations;

namespace Vadean_Flaviu_Proiect.Migrations
{
    public partial class PersoanaModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persoana_Localitate_LocalitateID",
                table: "Persoana");

            migrationBuilder.DropIndex(
                name: "IX_Persoana_LocalitateID",
                table: "Persoana");

            migrationBuilder.DropColumn(
                name: "LocalitateID",
                table: "Persoana");

            migrationBuilder.AddColumn<int>(
                name: "PersoanaID",
                table: "Localitate",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Localitate_PersoanaID",
                table: "Localitate",
                column: "PersoanaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Localitate_Persoana_PersoanaID",
                table: "Localitate",
                column: "PersoanaID",
                principalTable: "Persoana",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localitate_Persoana_PersoanaID",
                table: "Localitate");

            migrationBuilder.DropIndex(
                name: "IX_Localitate_PersoanaID",
                table: "Localitate");

            migrationBuilder.DropColumn(
                name: "PersoanaID",
                table: "Localitate");

            migrationBuilder.AddColumn<int>(
                name: "LocalitateID",
                table: "Persoana",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Persoana_LocalitateID",
                table: "Persoana",
                column: "LocalitateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persoana_Localitate_LocalitateID",
                table: "Persoana",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
