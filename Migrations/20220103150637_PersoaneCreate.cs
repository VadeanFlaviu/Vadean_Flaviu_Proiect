using Microsoft.EntityFrameworkCore.Migrations;

namespace Vadean_Flaviu_Proiect.Migrations
{
    public partial class PersoaneCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persoana",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNP = table.Column<int>(nullable: false),
                    NumePersoana = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    SectieVotareID = table.Column<int>(nullable: false),
                    LocalitateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persoana", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Persoana_Localitate_LocalitateID",
                        column: x => x.LocalitateID,
                        principalTable: "Localitate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persoana_LocalitateID",
                table: "Persoana",
                column: "LocalitateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persoana");
        }
    }
}
