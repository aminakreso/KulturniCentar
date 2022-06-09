using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KulturniCentar.Data.Models
{
    [Table("Admin")]
    public partial class Admin
    {
        public Admin()
        {
            Zahtjev = new HashSet<Zahtjev>();
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
        public virtual KorisnickiRacun KorisnickiRacun { get; set; }
        public virtual ICollection<Zahtjev> Zahtjev { get; set; }
    }
}
