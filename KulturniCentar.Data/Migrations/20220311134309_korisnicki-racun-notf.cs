using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class korisnickiracunnotf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotifikaicjAdmin",
                table: "Notifikacija");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Notifikacija",
                newName: "KorisnickiRacunId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifikacija_AdminId",
                table: "Notifikacija",
                newName: "IX_Notifikacija_KorisnickiRacunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifikaicja_KorisnickiRacun",
                table: "Notifikacija",
                column: "KorisnickiRacunId",
                principalTable: "KorisnickiRacun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifikaicja_KorisnickiRacun",
                table: "Notifikacija");

            migrationBuilder.RenameColumn(
                name: "KorisnickiRacunId",
                table: "Notifikacija",
                newName: "AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifikacija_KorisnickiRacunId",
                table: "Notifikacija",
                newName: "IX_Notifikacija_AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotifikaicjAdmin",
                table: "Notifikacija",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
