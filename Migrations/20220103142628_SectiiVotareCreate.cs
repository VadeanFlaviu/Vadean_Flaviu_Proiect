using Microsoft.EntityFrameworkCore.Migrations;

namespace Vadean_Flaviu_Proiect.Migrations
{
    public partial class SectiiVotareCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectieVotare",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(nullable: true),
                    LocalitateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectieVotare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SectieVotare_Localitate_LocalitateID",
                        column: x => x.LocalitateID,
                        principalTable: "Localitate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectieVotare_LocalitateID",
                table: "SectieVotare",
                column: "LocalitateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectieVotare");
        }
    }
}
