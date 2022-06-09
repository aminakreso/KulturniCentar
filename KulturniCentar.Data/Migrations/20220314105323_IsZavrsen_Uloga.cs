using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class IsZavrsen_Uloga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsZavrsen",
                table: "Zahtjev",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Uloga",
                table: "KorisnickiRacun",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsZavrsen",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "Uloga",
                table: "KorisnickiRacun");
        }
    }
}
