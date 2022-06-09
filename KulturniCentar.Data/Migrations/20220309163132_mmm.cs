using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KulturniCentar.Data.Migrations
{
    public partial class mmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiRacun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiRacun", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materijali",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Docx = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materijali", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bodovi = table.Column<double>(type: "float", nullable: true),
                    KonacnaOcjena = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjena", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uspjeh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prosjek = table.Column<double>(type: "float", nullable: true),
                    Percentile = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uspjeh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    KorisnickiRacunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KorisnickiRacunId_Admin",
                        column: x => x.KorisnickiRacunId,
                        principalTable: "KorisnickiRacun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Predavac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    KorisnickiRacunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predavac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KorisnickiRacun_Predavac",
                        column: x => x.KorisnickiRacunId,
                        principalTable: "KorisnickiRacun",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Polaznik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    KorisnickiRacunId = table.Column<int>(type: "int", nullable: false),
                    UspjehId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polaznik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Polaznik_KorsinickiRacun",
                        column: x => x.KorisnickiRacunId,
                        principalTable: "KorisnickiRacun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Polaznik_Uspjeh",
                        column: x => x.UspjehId,
                        principalTable: "Uspjeh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifikacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Sadrzaj = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifikacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotifikaicjAdmin",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MaxBrojPolaznika = table.Column<int>(type: "int", nullable: true),
                    PredavacId = table.Column<int>(type: "int", nullable: false),
                    KategorijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KursKategorija",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KursPredavac",
                        column: x => x.PredavacId,
                        principalTable: "Predavac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prisustvo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolaznikId = table.Column<int>(type: "int", nullable: false),
                    Prisutan = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prisustvo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrisustvoPolaznik",
                        column: x => x.PolaznikId,
                        principalTable: "Polaznik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KursNotifikacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursId = table.Column<int>(type: "int", nullable: false),
                    NotifikacijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursNotifikacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KursNotifikacija_Kurs",
                        column: x => x.KursId,
                        principalTable: "Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KursNotifikacija_Notifikacija",
                        column: x => x.NotifikacijaId,
                        principalTable: "Notifikacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zahtjev",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Napomena = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime", nullable: true),
                    KursId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    PolaznikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjev", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZahtjevAdmin",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZahtjevKurs",
                        column: x => x.KursId,
                        principalTable: "Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZahtjevPolaznik",
                        column: x => x.PolaznikId,
                        principalTable: "Polaznik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Odrzavanje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursId = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "date", nullable: true),
                    PrisustvoId = table.Column<int>(type: "int", nullable: false),
                    MaterijaliId = table.Column<int>(type: "int", nullable: false)
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
                    PolaznikId = table.Column<int>(type: "int", nullable: false),
                    OdrzavanjeId = table.Column<int>(type: "int", nullable: false),
                    jeZavrsen = table.Column<bool>(type: "bit", nullable: true),
                    OcjenaId = table.Column<int>(type: "int", nullable: true),
                    DatumPocetka = table.Column<DateTime>(type: "datetime", nullable: true),
                    DatumKraja = table.Column<DateTime>(type: "datetime", nullable: true)
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_KorisnickiRacunId",
                table: "Admin",
                column: "KorisnickiRacunId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurs_KategorijaId",
                table: "Kurs",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurs_PredavacId",
                table: "Kurs",
                column: "PredavacId");

            migrationBuilder.CreateIndex(
                name: "IX_KursNotifikacija_KursId",
                table: "KursNotifikacija",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_KursNotifikacija_NotifikacijaId",
                table: "KursNotifikacija",
                column: "NotifikacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifikacija_AdminId",
                table: "Notifikacija",
                column: "AdminId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Polaznik_KorisnickiRacunId",
                table: "Polaznik",
                column: "KorisnickiRacunId");

            migrationBuilder.CreateIndex(
                name: "IX_Polaznik_UspjehId",
                table: "Polaznik",
                column: "UspjehId");

            migrationBuilder.CreateIndex(
                name: "IX_Predavac_KorisnickiRacunId",
                table: "Predavac",
                column: "KorisnickiRacunId");

            migrationBuilder.CreateIndex(
                name: "IX_Prisustvo_PolaznikId",
                table: "Prisustvo",
                column: "PolaznikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_AdminId",
                table: "Zahtjev",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_KursId",
                table: "Zahtjev",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_PolaznikId",
                table: "Zahtjev",
                column: "PolaznikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KursNotifikacija");

            migrationBuilder.DropTable(
                name: "Pohadjanje");

            migrationBuilder.DropTable(
                name: "Zahtjev");

            migrationBuilder.DropTable(
                name: "Notifikacija");

            migrationBuilder.DropTable(
                name: "Ocjena");

            migrationBuilder.DropTable(
                name: "Odrzavanje");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Materijali");

            migrationBuilder.DropTable(
                name: "Kurs");

            migrationBuilder.DropTable(
                name: "Prisustvo");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropTable(
                name: "Predavac");

            migrationBuilder.DropTable(
                name: "Polaznik");

            migrationBuilder.DropTable(
                name: "KorisnickiRacun");

            migrationBuilder.DropTable(
                name: "Uspjeh");
        }
    }
}
