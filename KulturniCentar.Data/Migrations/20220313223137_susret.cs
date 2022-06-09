using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class susret : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materijali_Susret",
                table: "Materijali");

            migrationBuilder.DropForeignKey(
                name: "FK_Prisustvo_Susret",
                table: "Prisustvo");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterijaliSusret",
                table: "Materijali",
                column: "SusretId",
                principalTable: "Susret",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrisustvoSusret",
                table: "Prisustvo",
                column: "SusretId",
                principalTable: "Susret",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterijaliSusret",
                table: "Materijali");

            migrationBuilder.DropForeignKey(
                name: "FK_PrisustvoSusret",
                table: "Prisustvo");

            migrationBuilder.AddForeignKey(
                name: "FK_Materijali_Susret",
                table: "Materijali",
                column: "SusretId",
                principalTable: "Susret",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prisustvo_Susret",
                table: "Prisustvo",
                column: "SusretId",
                principalTable: "Susret",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
