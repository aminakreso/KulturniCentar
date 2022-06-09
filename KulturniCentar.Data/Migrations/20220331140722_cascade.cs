using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursKategorija",
                table: "Kurs");

            migrationBuilder.AddForeignKey(
                name: "FK_KursKategorija",
                table: "Kurs",
                column: "KategorijaId",
                principalTable: "Kategorija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursKategorija",
                table: "Kurs");

            migrationBuilder.AddForeignKey(
                name: "FK_KursKategorija",
                table: "Kurs",
                column: "KategorijaId",
                principalTable: "Kategorija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
