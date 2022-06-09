using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KulturniCentar.Data.Models
{
    [Table("Predavac")]
    public partial class Predavac
    {
        public Predavac()
        {
            Kurs = new HashSet<Kurs>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Ime { get; set; }
        [Required]
        [StringLength(30)]
        public string Prezime { get; set; }
        [Required]
        [StringLength(40)]
        public string Email { get; set; }
        [Required]
        [StringLength(15)]
        public string Telefon { get; set; }
        public int KorisnickiRacunId { get; set; }

        [ForeignKey(nameof(KorisnickiRacunId))]
        [InverseProperty("Predavac")]
        public virtual KorisnickiRacun KorisnickiRacun { get; set; }
        public virtual ICollection<Kurs> Kurs { get; set; }
    }
}
