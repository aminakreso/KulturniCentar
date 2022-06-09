using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class uwt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "UserWithToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickiRacunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWithToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWithToken_KorisnickiRacun_KorisnickiRacunId",
                        column: x => x.KorisnickiRacunId,
                        principalTable: "KorisnickiRacun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserWithToken_KorisnickiRacunId",
                table: "UserWithToken",
                column: "KorisnickiRacunId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserWithToken");

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
