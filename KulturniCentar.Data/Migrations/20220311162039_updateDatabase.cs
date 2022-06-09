using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class updateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pohadjanje");

            migrationBuilder.DropTable(
                name: "Odrzavanje");

            migrationBuilder.AddColumn<int>(
                name: "SusretId",
                table: "Prisustvo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CiklusId",
                table: "Polaznik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CiklusId",
                table: "Ocjena",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PolaznikId",
                table: "Ocjena",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SusretId",
                table: "Materijali",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ciklus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursId = table.Column<int>(type: "int", nullable: false),
                    jeZavrsen = table.Column<bool>(type: "bit", nullable: true),
                    DatumPocetka = table.Column<DateTime>(type: "datetime", nullable: true),
                    DatumKraja = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciklus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kurs_Ciklus",
                        column: x => x.KursId,
                        principalTable: "Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Susret",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CiklusId = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Susret", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odrzavanje_Kurs",
                        column: x => x.CiklusId,
                        principalTable: "Ciklus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prisustvo_SusretId",
                table: "Prisustvo",
                column: "SusretId");

            migrationBuilder.CreateIndex(
                name: "IX_Polaznik_CiklusId",
                table: "Polaznik",
                column: "CiklusId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_CiklusId",
                table: "Ocjena",
                column: "CiklusId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_PolaznikId",
                table: "Ocjena",
                column: "PolaznikId");

            migrationBuilder.CreateIndex(
                name: "IX_Materijali_SusretId",
                table: "Materijali",
                column: "SusretId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciklus_KursId",
                table: "Ciklus",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_Susret_CiklusId",
                table: "Susret",
                column: "CiklusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materijali_Susret",
                table: "Materijali",
                column: "SusretId",
                principalTable: "Susret",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjena_Ciklus_CiklusId",
                table: "Ocjena",
                column: "CiklusId",
                principalTable: "Ciklus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjena_Polaznik_PolaznikId",
                table: "Ocjena",
                column: "PolaznikId",
                principalTable: "Polaznik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Polaznik_Ciklus",
                table: "Polaznik",
                column: "CiklusId",
                principalTable: "Ciklus",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Prisustvo_Susret",
                table: "Prisustvo",
                column: "SusretId",
                principalTable: "Susret",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materijali_Susret",
                table: "Materijali");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocjena_Ciklus_CiklusId",
                table: "Ocjena");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocjena_Polaznik_PolaznikId",
                table: "Ocjena");

            migrationBuilder.DropForeignKey(
                name: "FK_Polaznik_Ciklus",
                table: "Polaznik");

            migrationBuilder.DropForeignKey(
                name: "FK_Prisustvo_Susret",
                table: "Prisustvo");

            migrationBuilder.DropTable(
                name: "Susret");

            migrationBuilder.DropTable(
                name: "Ciklus");

            migrationBuilder.DropIndex(
                name: "IX_Prisustvo_SusretId",
                table: "Prisustvo");

            migrationBuilder.DropIndex(
                name: "IX_Polaznik_CiklusId",
                table: "Polaznik");

            migrationBuilder.DropIndex(
                name: "IX_Ocjena_CiklusId",
                table: "Ocjena");

            migrationBuilder.DropIndex(
                name: "IX_Ocjena_PolaznikId",
                table: "Ocjena");

            migrationBuilder.DropIndex(
                name: "IX_Materijali_SusretId",
                table: "Materijali");

            migrationBuilder.DropColumn(
                name: "SusretId",
                table: "Prisustvo");

            migrationBuilder.DropColumn(
                name: "CiklusId",
                table: "Polaznik");

            migrationBuilder.DropColumn(
                name: "CiklusId",
                table: "Ocjena");

            migrationBuilder.DropColumn(
                name: "PolaznikId",
                table: "Ocjena");

            migrationBuilder.DropColumn(
                name: "SusretId",
                table: "Materijali");

            migrationBuilder.CreateTable(
                name: "Odrzavanje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "date", nullable: true),
                    KursId = table.Column<int>(type: "int", nullable: false),
                    MaterijaliId = table.Column<int>(type: "int", nullable: false),
                    PrisustvoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odrzavanje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odravanje_Materijali",
                        column: x => x.MaterijaliId,
                        principalTable: "Materijali",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Odrzavanje_Kurs",
                        column: x => x.KursId,
                        principalTable: "Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Odrzavanje_Prisustvo",
                        column: x => x.PrisustvoId,
                        principalTable: "Prisustvo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pohadjanje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumKraja = table.Column<DateTime>(type: "datetime", nullable: true),
                    DatumPocetka = table.Column<DateTime>(type: "datetime", nullable: true),
                    jeZavrsen = table.Column<bool>(type: "bit", nullable: true),
                    OcjenaId = table.Column<int>(type: "int", nullable: true),
                    OdrzavanjeId = table.Column<int>(type: "int", nullable: false),
                    PolaznikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pohadjanje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pohadjanje_Ocjena",
                        column: x => x.OcjenaId,
                        principalTable: "Ocjena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pohadjanje_Odrzavanje",
                        column: x => x.OdrzavanjeId,
                        principalTable: "Odrzavanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pohadjanje_Polaznik",
                        column: x => x.PolaznikId,
                        principalTable: "Polaznik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Odrzavanje_KursId",
                table: "Odrzavanje",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_Odrzavanje_MaterijaliId",
                table: "Odrzavanje",
                column: "MaterijaliId");

            migrationBuilder.CreateIndex(
                name: "IX_Odrzavanje_PrisustvoId",
                table: "Odrzavanje",
                column: "PrisustvoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pohadjanje_OcjenaId",
                table: "Pohadjanje",
                column: "OcjenaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pohadjanje_OdrzavanjeId",
                table: "Pohadjanje",
                column: "OdrzavanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pohadjanje_PolaznikId",
                table: "Pohadjanje",
                column: "PolaznikId");
        }
    }
}
