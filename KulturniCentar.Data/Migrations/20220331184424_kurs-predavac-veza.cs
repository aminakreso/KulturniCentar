using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class kurspredavacveza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursPredavac",
                table: "Kurs");

            migrationBuilder.AddForeignKey(
                name: "FK_KursPredavac",
                table: "Kurs",
                column: "PredavacId",
                principalTable: "Predavac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursPredavac",
                table: "Kurs");

            migrationBuilder.AddForeignKey(
                name: "FK_KursPredavac",
                table: "Kurs",
                column: "PredavacId",
                principalTable: "Predavac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
