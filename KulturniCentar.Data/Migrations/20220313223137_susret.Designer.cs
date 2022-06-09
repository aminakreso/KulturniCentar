﻿// <auto-generated />
using System;
using KulturniCentar.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KulturniCentar.Data.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20220313223137_susret")]
    partial class susret
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KulturniCentar.Data.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("KorisnickiRacunId")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiRacunId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Ciklus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DatumKraja")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DatumPocetka")
                        .HasColumnType("datetime");

                    b.Property<bool>("JeZavrsen")
                        .HasColumnType("bit")
                        .HasColumnName("jeZavrsen");

                    b.Property<int>("KursId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KursId");

                    b.ToTable("Ciklus");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Kategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Opis")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Kategorija");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.KorisnickiRacun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("KorisnickiRacun");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Kurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KategorijaId")
                        .HasColumnType("int");

                    b.Property<int?>("MaxBrojPolaznika")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PredavacId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KategorijaId");

                    b.HasIndex("PredavacId");

                    b.ToTable("Kurs");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.KursNotifikacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KursId")
                        .HasColumnType("int");

                    b.Property<int>("NotifikacijaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KursId");

                    b.HasIndex("NotifikacijaId");

                    b.ToTable("KursNotifikacija");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Materijali", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Docx")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Naziv")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("SusretId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SusretId");

                    b.ToTable("Materijali");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Notifikacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Datum")
                        .HasColumnType("datetime");

                    b.Property<int>("KorisnickiRacunId")
                        .HasColumnType("int");

                    b.Property<string>("Naslov")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Sadrzaj")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiRacunId");

                    b.ToTable("Notifikacija");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Ocjena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("Bodovi")
                        .HasColumnType("float");

                    b.Property<int>("CiklusId")
                        .HasColumnType("int");

                    b.Property<int?>("KonacnaOcjena")
                        .HasColumnType("int");

                    b.Property<int>("PolaznikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CiklusId");

                    b.HasIndex("PolaznikId");

                    b.ToTable("Ocjena");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Polaznik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CiklusId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("KorisnickiRacunId")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("UspjehId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CiklusId");

                    b.HasIndex("KorisnickiRacunId");

                    b.HasIndex("UspjehId");

                    b.ToTable("Polaznik");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.PolaznikCiklus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CiklusId")
                        .HasColumnType("int");

                    b.Property<int>("PolaznikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CiklusId");

                    b.HasIndex("PolaznikId");

                    b.ToTable("PolaznikCiklus");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Predavac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("KorisnickiRacunId")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiRacunId");

                    b.ToTable("Predavac");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Prisustvo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PolaznikId")
                        .HasColumnType("int");

                    b.Property<bool?>("Prisutan")
                        .HasColumnType("bit");

                    b.Property<int>("SusretId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PolaznikId");

                    b.HasIndex("SusretId");

                    b.ToTable("Prisustvo");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Susret", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CiklusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Datum")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CiklusId");

                    b.ToTable("Susret");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Uspjeh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Percentile")
                        .HasColumnType("int");

                    b.Property<double?>("Prosjek")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Uspjeh");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Zahtjev", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Datum")
                        .HasColumnType("datetime");

                    b.Property<int>("KursId")
                        .HasColumnType("int");

                    b.Property<string>("Napomena")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Naslov")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("PolaznikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("KursId");

                    b.HasIndex("PolaznikId");

                    b.ToTable("Zahtjev");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Admin", b =>
                {
                    b.HasOne("KulturniCentar.Data.Models.KorisnickiRacun", "KorisnickiRacun")
                        .WithMany("Admin")
                        .HasForeignKey("KorisnickiRacunId")
                        .HasConstraintName("FK_KorisnickiRacunId_Admin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KorisnickiRacun");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Ciklus", b =>
                {
                    b.HasOne("KulturniCentar.Data.Models.Kurs", "Kurs")
                        .WithMany("Ciklusi")
                        .HasForeignKey("KursId")
                        .HasConstraintName("FK_Kurs_Ciklus")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Kurs");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Kurs", b =>
                {
                    b.HasOne("KulturniCentar.Data.Models.Kategorija", "Kategorija")
                        .WithMany("Kurs")
                        .HasForeignKey("KategorijaId")
                        .HasConstraintName("FK_KursKategorija")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KulturniCentar.Data.Models.Predavac", "Predavac")
                        .WithMany("Kurs")
                        .HasForeignKey("PredavacId")
                        .HasConstraintName("FK_KursPredavac")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Kategorija");

                    b.Navigation("Predavac");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.KursNotifikacija", b =>
                {
                    b.HasOne("KulturniCentar.Data.Models.Kurs", "Kurs")
                        .WithMany("KursNotifikacija")
                        .HasForeignKey("KursId")
                        .HasConstraintName("FK_KursNotifikacija_Kurs")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KulturniCentar.Data.Models.Notifikacija", "Notifikacija")
                        .WithMany("KursNotifikacija")
                        .HasForeignKey("NotifikacijaId")
                        .HasConstraintName("FK_KursNotifikacija_Notifikacija")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kurs");

                    b.Navigation("Notifikacija");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Materijali", b =>
                {
                    b.HasOne("KulturniCentar.Data.Models.Susret", "Susret")
                        .WithMany("Materijali")
                        .HasForeignKey("SusretId")
                        .HasConstraintName("FK_MaterijaliSusret")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Susret");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Notifikacija", b =>
                {
                    b.HasOne("KulturniCentar.Data.Models.KorisnickiRacun", "KorisnickiRacun")
                        .WithMany("Notifikacija")
                        .HasForeignKey("KorisnickiRacunId")
                        .HasConstraintName("FK_Notifikaicja_KorisnickiRacun")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KorisnickiRacun");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Ocjena", b =>
                {
                    b.HasOne("KulturniCentar.Data.Models.Ciklus", "Ciklus")
                        .WithMany()
                        .HasForeignKey("CiklusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KulturniCentar.Data.Models.Polaznik", "Polaznik")
                        .WithMany()
                        .HasForeignKey("PolaznikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciklus");

                    b.Navigation("Polaznik");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Polaznik", b =>
                {
                    b.HasOne("KulturniCentar.Data.Models.Ciklus", null)
                        .WithMany("Polaznici")
                        .HasForeignKey("CiklusId");

                    b.HasOne("KulturniCentar.Data.Models.KorisnickiRacun", "KorisnickiRacun")
                        .WithMany("Polaznik")
                        .HasForeignKey("KorisnickiRacunId")
                        .HasConstraintName("FK_Polaznik_KorsinickiRacun")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KulturniCentar.Data.Models.Uspjeh", "Uspjeh")
                        .WithMany("Polaznik")
                        .HasForeignKey("UspjehId")
                        .HasConstraintName("FK_Polaznik_Uspjeh")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("KorisnickiRacun");

                    b.Navigation("Uspjeh");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.PolaznikCiklus", b =>
                {
                    b.HasOne("KulturniCentar.Data.Models.Ciklus", "Ciklus")
                        .WithMany()
                        .HasForeignKey("CiklusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KulturniCentar.Data.Models.Polaznik", "Polaznik")
                        .WithMany()
                        .HasForeignKey("PolaznikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciklus");

                    b.Navigation("Polaznik");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Predavac", b =>
                {
                    b.HasOne("KulturniCentar.Data.Models.KorisnickiRacun", "KorisnickiRacun")
                        .WithMany("Predavac")
                        .HasForeignKey("KorisnickiRacunId")
                        .HasConstraintName("FK_KorisnickiRacun_Predavac")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("KorisnickiRacun");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Prisustvo", b =>
                {
                    b.HasOne("KulturniCentar.Data.Models.Polaznik", "Polaznik")
                        .WithMany("Prisustvo")
                        .HasForeignKey("PolaznikId")
                        .HasConstraintName("FK_PrisustvoPolaznik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KulturniCentar.Data.Models.Susret", "Susret")
                        .WithMany("Prisustvo")
                        .HasForeignKey("SusretId")
                        .HasConstraintName("FK_PrisustvoSusret")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Polaznik");

                    b.Navigation("Susret");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Susret", b =>
                {
                    b.HasOne("KulturniCentar.Data.Models.Ciklus", "Ciklus")
                        .WithMany("Susreti")
                        .HasForeignKey("CiklusId")
                        .HasConstraintName("FK_Odrzavanje_Kurs")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciklus");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Zahtjev", b =>
                {
                    b.HasOne("KulturniCentar.Data.Models.Admin", "Admin")
                        .WithMany("Zahtjev")
                        .HasForeignKey("AdminId")
                        .HasConstraintName("FK_ZahtjevAdmin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KulturniCentar.Data.Models.Kurs", "Kurs")
                        .WithMany("Zahtjev")
                        .HasForeignKey("KursId")
                        .HasConstraintName("FK_ZahtjevKurs")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KulturniCentar.Data.Models.Polaznik", "Polaznik")
                        .WithMany("Zahtjev")
                        .HasForeignKey("PolaznikId")
                        .HasConstraintName("FK_ZahtjevPolaznik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Kurs");

                    b.Navigation("Polaznik");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Admin", b =>
                {
                    b.Navigation("Zahtjev");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Ciklus", b =>
                {
                    b.Navigation("Polaznici");

                    b.Navigation("Susreti");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Kategorija", b =>
                {
                    b.Navigation("Kurs");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.KorisnickiRacun", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Notifikacija");

                    b.Navigation("Polaznik");

                    b.Navigation("Predavac");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Kurs", b =>
                {
                    b.Navigation("Ciklusi");

                    b.Navigation("KursNotifikacija");

                    b.Navigation("Zahtjev");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Notifikacija", b =>
                {
                    b.Navigation("KursNotifikacija");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Polaznik", b =>
                {
                    b.Navigation("Prisustvo");

                    b.Navigation("Zahtjev");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Predavac", b =>
                {
                    b.Navigation("Kurs");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Susret", b =>
                {
                    b.Navigation("Materijali");

                    b.Navigation("Prisustvo");
                });

            modelBuilder.Entity("KulturniCentar.Data.Models.Uspjeh", b =>
                {
                    b.Navigation("Polaznik");
                });
#pragma warning restore 612, 618
        }
    }
}
