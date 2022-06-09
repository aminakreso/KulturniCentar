using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class polaznikCiklus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolaznikCiklus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolaznikId = table.Column<int>(type: "int", nullable: false),
                    CiklusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolaznikCiklus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolaznikCiklus_Ciklus_CiklusId",
                        column: x => x.CiklusId,
                        principalTable: "Ciklus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolaznikCiklus_Polaznik_PolaznikId",
                        column: x => x.PolaznikId,
                        principalTable: "Polaznik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PolaznikCiklus_CiklusId",
                table: "PolaznikCiklus",
                column: "CiklusId");

            migrationBuilder.CreateIndex(
                name: "IX_PolaznikCiklus_PolaznikId",
                table: "PolaznikCiklus",
                column: "PolaznikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolaznikCiklus");
        }
    }
}
