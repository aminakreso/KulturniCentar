using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class cascadeciklus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kurs_Ciklus",
                table: "Ciklus");

            migrationBuilder.AddForeignKey(
                name: "FK_Kurs_Ciklus",
                table: "Ciklus",
                column: "KursId",
                principalTable: "Kurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kurs_Ciklus",
                table: "Ciklus");

            migrationBuilder.AddForeignKey(
                name: "FK_Kurs_Ciklus",
                table: "Ciklus",
                column: "KursId",
                principalTable: "Kurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
