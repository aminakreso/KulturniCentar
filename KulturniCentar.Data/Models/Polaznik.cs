using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KulturniCentar.Data.Models
{
    [Table("Polaznik")]
    public partial class Polaznik
    {
        //public Polaznik()
        //{
        //    Prisustvo = new HashSet<Prisustvo>();
        //    Zahtjev = new HashSet<Zahtjev>();
        //}

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

        public int? UspjehId { get; set; }
        public string Slika { get; set; }

        //[ForeignKey(nameof(KorisnickiRacunId))]
        //[InverseProperty("Polaznik")]
        public virtual KorisnickiRacun KorisnickiRacun { get; set; }
        //[ForeignKey(nameof(UspjehId))]
        //[InverseProperty("Polaznik")]
        public virtual Uspjeh Uspjeh { get; set; }
        public virtual List<Prisustvo> Prisustvo { get; set; }
        public virtual List<Zahtjev> Zahtjev { get; set; }
        public List<PolaznikCiklus> PolaznikCiklus { get; set; }
        //public List<Ocjena> Ocjena { get; set; }

    }
}
