using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class @ref : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_KorisnickiRacun_KorisnickiRacunId",
                table: "RefreshToken");

            migrationBuilder.AddForeignKey(
                name: "Fk_rf",
                table: "RefreshToken",
                column: "KorisnickiRacunId",
                principalTable: "KorisnickiRacun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Fk_rf",
                table: "RefreshToken");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_KorisnickiRacun_KorisnickiRacunId",
                table: "RefreshToken",
                column: "KorisnickiRacunId",
                principalTable: "KorisnickiRacun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
