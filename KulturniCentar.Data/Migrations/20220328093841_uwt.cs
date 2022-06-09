using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class uwt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "KorisnickiRacun",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "KorisnickiRacun",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "KorisnickiRacunId",
                table: "KorisnickiRacun",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KorisnickiRacun_KorisnickiRacunId",
                table: "KorisnickiRacun",
                column: "KorisnickiRacunId");

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnickiRacun_KorisnickiRacun_KorisnickiRacunId",
                table: "KorisnickiRacun",
                column: "KorisnickiRacunId",
                principalTable: "KorisnickiRacun",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnickiRacun_KorisnickiRacun_KorisnickiRacunId",
                table: "KorisnickiRacun");

            migrationBuilder.DropIndex(
                name: "IX_KorisnickiRacun_KorisnickiRacunId",
                table: "KorisnickiRacun");

            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "KorisnickiRacun");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "KorisnickiRacun");

            migrationBuilder.DropColumn(
                name: "KorisnickiRacunId",
                table: "KorisnickiRacun");
        }
    }
}
