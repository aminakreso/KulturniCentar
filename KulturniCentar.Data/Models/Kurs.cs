using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KulturniCentar.Data.Models
{
    [Table("Kurs")]
    public partial class Kurs
    { 
        public Kurs()
        {
            Zahtjev = new HashSet<Zahtjev>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Naziv { get; set; }
        public int? MaxBrojPolaznika { get; set; }
        public int PredavacId { get; set; }
        public int KategorijaId { get; set; }
        //public int? MaterijaliId { get; set; }

        public virtual Kategorija Kategorija { get; set; }
        //public virtual Materijali Materijali { get; set; }
        public virtual Predavac Predavac { get; set; }
        public List<Ciklus> Ciklusi { get; set; }
        public List<KursNotifikacija> KursNotifikacija { get; set; }
       // public virtual ICollection<Susret> Susret { get; set; }
        public virtual ICollection<Zahtjev> Zahtjev { get; set; }
    }
}
