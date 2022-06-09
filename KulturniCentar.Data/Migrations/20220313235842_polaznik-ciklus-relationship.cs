using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class polaznikciklusrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polaznik_Ciklus_CiklusId",
                table: "Polaznik");

            migrationBuilder.DropForeignKey(
                name: "FK_PolaznikCiklus_Ciklus_CiklusId",
                table: "PolaznikCiklus");

            migrationBuilder.DropForeignKey(
                name: "FK_PolaznikCiklus_Polaznik_PolaznikId",
                table: "PolaznikCiklus");

            migrationBuilder.DropIndex(
                name: "IX_Polaznik_CiklusId",
                table: "Polaznik");

            migrationBuilder.DropColumn(
                name: "CiklusId",
                table: "Polaznik");

            migrationBuilder.AddForeignKey(
                name: "FK_PolaznikCiklus_Ciklus",
                table: "PolaznikCiklus",
                column: "CiklusId",
                principalTable: "Ciklus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolaznikCiklus_Polaznik",
                table: "PolaznikCiklus",
                column: "PolaznikId",
                principalTable: "Polaznik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolaznikCiklus_Ciklus",
                table: "PolaznikCiklus");

            migrationBuilder.DropForeignKey(
                name: "FK_PolaznikCiklus_Polaznik",
                table: "PolaznikCiklus");

            migrationBuilder.AddColumn<int>(
                name: "CiklusId",
                table: "Polaznik",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Polaznik_CiklusId",
                table: "Polaznik",
                column: "CiklusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Polaznik_Ciklus_CiklusId",
                table: "Polaznik",
                column: "CiklusId",
                principalTable: "Ciklus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PolaznikCiklus_Ciklus_CiklusId",
                table: "PolaznikCiklus",
                column: "CiklusId",
                principalTable: "Ciklus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolaznikCiklus_Polaznik_PolaznikId",
                table: "PolaznikCiklus",
                column: "PolaznikId",
                principalTable: "Polaznik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
