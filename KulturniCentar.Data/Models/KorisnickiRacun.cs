using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KulturniCentar.Data.Models
{
    [Table("KorisnickiRacun")]
    public partial class KorisnickiRacun
    {
        public KorisnickiRacun()
        {
            Admin = new HashSet<Admin>();
            Polaznik = new HashSet<Polaznik>();
            Predavac = new HashSet<Predavac>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string KorisnickoIme { get; set; }
        [Required]
        [StringLength(30)]
        public string Lozinka { get; set; }

        public string Uloga { get; set; }

        public virtual ICollection<Admin> Admin { get; set; }
        public virtual ICollection<Polaznik> Polaznik { get; set; }
        public virtual ICollection<Predavac> Predavac { get; set; }
        public virtual List<Notifikacija> Notifikacija { get; set; }
        public virtual ICollection<RefreshToken> RefreshToken { get; set; }


    }
}
