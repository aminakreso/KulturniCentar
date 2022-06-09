using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class materijaliedittabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Docx",
                table: "Materijali",
                newName: "DataFiles");

            migrationBuilder.AddColumn<DateTime>(
                name: "Kreirano",
                table: "Materijali",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Tip",
                table: "Materijali",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kreirano",
                table: "Materijali");

            migrationBuilder.DropColumn(
                name: "Tip",
                table: "Materijali");

            migrationBuilder.RenameColumn(
                name: "DataFiles",
                table: "Materijali",
                newName: "Docx");
        }
    }
}
