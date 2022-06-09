using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class polaznikCiklusremoveKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polaznik_Ciklus",
                table: "Polaznik");

            migrationBuilder.AlterColumn<int>(
                name: "CiklusId",
                table: "Polaznik",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Polaznik_Ciklus_CiklusId",
                table: "Polaznik",
                column: "CiklusId",
                principalTable: "Ciklus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polaznik_Ciklus_CiklusId",
                table: "Polaznik");

            migrationBuilder.AlterColumn<int>(
                name: "CiklusId",
                table: "Polaznik",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Polaznik_Ciklus",
                table: "Polaznik",
                column: "CiklusId",
                principalTable: "Ciklus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
