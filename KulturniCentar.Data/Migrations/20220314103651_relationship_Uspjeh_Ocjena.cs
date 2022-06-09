using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class relationship_Uspjeh_Ocjena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polaznik_Uspjeh",
                table: "Polaznik");

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
                name: "FK_Uspjeh_Ocjena",
                table: "Ocjena",
                column: "UspjehId",
                principalTable: "Uspjeh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Polaznik_Uspjeh_UspjehId",
                table: "Polaznik",
                column: "UspjehId",
                principalTable: "Uspjeh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uspjeh_Ocjena",
                table: "Ocjena");

            migrationBuilder.DropForeignKey(
                name: "FK_Polaznik_Uspjeh_UspjehId",
                table: "Polaznik");

            migrationBuilder.DropIndex(
                name: "IX_Ocjena_UspjehId",
                table: "Ocjena");

            migrationBuilder.DropColumn(
                name: "UspjehId",
                table: "Ocjena");

            migrationBuilder.AddForeignKey(
                name: "FK_Polaznik_Uspjeh",
                table: "Polaznik",
                column: "UspjehId",
                principalTable: "Uspjeh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
