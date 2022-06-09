using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class kk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocjena_Ciklus_CiklusId",
                table: "Ocjena");

            migrationBuilder.DropForeignKey(
                name: "FK_Polaznik_Ocjena",
                table: "Ocjena");

            migrationBuilder.DropIndex(
                name: "IX_Ocjena_CiklusId",
                table: "Ocjena");

            migrationBuilder.DropIndex(
                name: "IX_Ocjena_PolaznikId",
                table: "Ocjena");

            migrationBuilder.DropColumn(
                name: "Bodovi",
                table: "Ocjena");

            migrationBuilder.DropColumn(
                name: "CiklusId",
                table: "Ocjena");

            migrationBuilder.DropColumn(
                name: "KonacnaOcjena",
                table: "Ocjena");

            migrationBuilder.DropColumn(
                name: "PolaznikId",
                table: "Ocjena");

            migrationBuilder.AddColumn<double>(
                name: "Bodovi",
                table: "PolaznikCiklus",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KonacnaOcjena",
                table: "PolaznikCiklus",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bodovi",
                table: "PolaznikCiklus");

            migrationBuilder.DropColumn(
                name: "KonacnaOcjena",
                table: "PolaznikCiklus");

            migrationBuilder.AddColumn<double>(
                name: "Bodovi",
                table: "Ocjena",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CiklusId",
                table: "Ocjena",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KonacnaOcjena",
                table: "Ocjena",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PolaznikId",
                table: "Ocjena",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_CiklusId",
                table: "Ocjena",
                column: "CiklusId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_PolaznikId",
                table: "Ocjena",
                column: "PolaznikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjena_Ciklus_CiklusId",
                table: "Ocjena",
                column: "CiklusId",
                principalTable: "Ciklus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Polaznik_Ocjena",
                table: "Ocjena",
                column: "PolaznikId",
                principalTable: "Polaznik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
