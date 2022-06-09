using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KulturniCentar.Data.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options): base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Kategorija> Kategorija { get; set; }
        public virtual DbSet<KorisnickiRacun> KorisnickiRacun { get; set; }
        public virtual DbSet<Kurs> Kurs { get; set; }
        public virtual DbSet<KursNotifikacija> KursNotifikacija { get; set; }
        public virtual DbSet<Materijali> Materijali { get; set; }
        public virtual DbSet<Notifikacija> Notifikacija { get; set; }
        public virtual DbSet<Susret> Susret { get; set; }
        public virtual DbSet<Ciklus> Ciklus { get; set; }
        public virtual DbSet<Polaznik> Polaznik { get; set; }
        public virtual DbSet<Predavac> Predavac { get; set; }
        public virtual DbSet<Prisustvo> Prisustvo { get; set; }
        public virtual DbSet<Uspjeh> Uspjeh { get; set; }
        public virtual DbSet<Zahtjev> Zahtjev { get; set; }
        public virtual DbSet<PolaznikCiklus> PolaznikCiklus { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<UserWithToken> UserWithToken { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = app.fit.ba,1431; Database = p2050_; Trusted_Connection = false;User Id = p2050_; Password = bRBUXP2!; MultipleActiveResultSets = true; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasOne(d => d.KorisnickiRacun)
                    .WithMany(p => p.Admin)
                    .HasForeignKey(d => d.KorisnickiRacunId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_KorisnickiRacunId_Admin");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                //entity.HasKey(e => e.Id)
                //    .HasName("PK_rf");

                //entity.ToTable("RefreshToken");

                //entity.Property(e => e.TokenId)
                //    .ValueGeneratedNever()
                //    .HasColumnName("TokenID");

                //entity.Property(e => e.ExpiryDate)
                //    .HasColumnType("datetime")
                //    .HasColumnName("Expiry_date");

                //entity.Property(e => e.KorisnickiRacunID).HasColumnName("KorisnickiRacunID");

                //entity.Property(e => e.Token)
                //    .HasMaxLength(200)
                //    .IsUnicode(false);

                entity.HasOne(d => d.KorisnickiRacun)
                    .WithMany(p => p.RefreshToken)
                    .HasForeignKey(d => d.KorisnickiRacunId)
                    .HasConstraintName("Fk_rf");
            });

            modelBuilder.Entity<Kurs>(entity =>
            {
                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Kurs)
                    .HasForeignKey(d => d.KategorijaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_KursKategorija");

                entity.HasOne(d => d.Predavac)
                    .WithMany(p => p.Kurs)
                    .HasForeignKey(d => d.PredavacId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_KursPredavac");
            });
            modelBuilder.Entity<Ciklus>(entity =>
            {
                entity.HasOne(d => d.Kurs)
                    .WithMany(p => p.Ciklusi)
                    .HasForeignKey(d => d.KursId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Kurs_Ciklus");

            });

            modelBuilder.Entity<KursNotifikacija>(entity =>
            {
                entity.HasOne(d => d.Kurs)
                    .WithMany(p => p.KursNotifikacija)
                    .HasForeignKey(d => d.KursId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_KursNotifikacija_Kurs");

                entity.HasOne(d => d.Notifikacija)
                    .WithMany(p => p.KursNotifikacija)
                    .HasForeignKey(d => d.NotifikacijaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_KursNotifikacija_Notifikacija");
            });
            modelBuilder.Entity<PolaznikCiklus>(entity =>
            {
                entity.HasOne(d => d.Ciklus)
                    .WithMany(p => p.PolaznikCiklus)
                    .HasForeignKey(d => d.CiklusId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PolaznikCiklus_Ciklus");

                entity.HasOne(d => d.Polaznik)
                    .WithMany(p => p.PolaznikCiklus)
                    .HasForeignKey(d => d.PolaznikId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PolaznikCiklus_Polaznik");
            });

            modelBuilder.Entity<Notifikacija>(entity =>
            {
                entity.HasOne(d => d.KorisnickiRacun)
                    .WithMany(p => p.Notifikacija)
                    .HasForeignKey(d => d.KorisnickiRacunId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Notifikaicja_KorisnickiRacun");
            });

            modelBuilder.Entity<Susret>(entity =>
            {
                entity.HasOne(d => d.Ciklus)
                    .WithMany(p => p.Susreti)
                    .HasForeignKey(d => d.CiklusId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Odrzavanje_Kurs");
                
            });


            modelBuilder.Entity<Polaznik>(entity =>
            {
                entity.HasOne(d => d.KorisnickiRacun)
                    .WithMany(p => p.Polaznik)
                    .HasForeignKey(d => d.KorisnickiRacunId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Polaznik_KorsinickiRacun");
            });

            modelBuilder.Entity<Predavac>(entity =>
            {
                entity.HasOne(d => d.KorisnickiRacun)
                    .WithMany(p => p.Predavac)
                    .HasForeignKey(d => d.KorisnickiRacunId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_KorisnickiRacun_Predavac");
            });

            modelBuilder.Entity<Prisustvo>(entity =>
            {
                entity.HasOne(d => d.Polaznik)
                    .WithMany(p => p.Prisustvo)
                    .HasForeignKey(d => d.PolaznikId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PrisustvoPolaznik");

                entity.HasOne(d => d.Susret)
                   .WithMany(p => p.Prisustvo)
                   .HasForeignKey(d => d.SusretId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_PrisustvoSusret");
            });
            modelBuilder.Entity<Materijali>(entity =>
            {
                entity.HasOne(d => d.Susret)
                    .WithMany(p => p.Materijali)
                    .HasForeignKey(d => d.SusretId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MaterijaliSusret");

            });

            modelBuilder.Entity<Zahtjev>(entity =>
            {
                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Zahtjev)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ZahtjevAdmin");

                entity.HasOne(d => d.Kurs)
                    .WithMany(p => p.Zahtjev)
                    .HasForeignKey(d => d.KursId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ZahtjevKurs");

                entity.HasOne(d => d.Polaznik)
                    .WithMany(p => p.Zahtjev)
                    .HasForeignKey(d => d.PolaznikId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ZahtjevPolaznik");
            }); 
            
          

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
