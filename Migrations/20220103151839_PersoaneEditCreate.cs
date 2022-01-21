using Microsoft.EntityFrameworkCore.Migrations;

namespace Vadean_Flaviu_Proiect.Migrations
{
    public partial class PersoaneEditCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Persoana_SectieVotareID",
                table: "Persoana",
                column: "SectieVotareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persoana_SectieVotare_SectieVotareID",
                table: "Persoana",
                column: "SectieVotareID",
                principalTable: "SectieVotare",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persoana_SectieVotare_SectieVotareID",
                table: "Persoana");

            migrationBuilder.DropIndex(
                name: "IX_Persoana_SectieVotareID",
                table: "Persoana");
        }
    }
}
