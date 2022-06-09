using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class ocjenepolaznik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocjena_Polaznik_PolaznikId",
                table: "Ocjena");

            migrationBuilder.DropForeignKey(
                name: "FK_Uspjeh_Ocjena",
                table: "Ocjena");

            migrationBuilder.DropIndex(
                name: "IX_Ocjena_UspjehId",
                table: "Ocjena");

            migrationBuilder.DropColumn(
                name: "UspjehId",
                table: "Ocjena");

            migrationBuilder.AddForeignKey(
                name: "FK_Polaznik_Ocjena",
                table: "Ocjena",
                column: "PolaznikId",
                principalTable: "Polaznik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polaznik_Ocjena",
                table: "Ocjena");

            migrationBuilder.AddColumn<int>(
                name: "UspjehId",
                table: "Ocjena",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_UspjehId",
                table: "Ocjena",
                column: "UspjehId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjena_Polaznik_PolaznikId",
                table: "Ocjena",
                column: "PolaznikId",
                principalTable: "Polaznik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uspjeh_Ocjena",
                table: "Ocjena",
                column: "UspjehId",
                principalTable: "Uspjeh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
