using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KulturniCentar.Data.Models
{
    [Table("Kategorija")]
    public partial class Kategorija
    {
        public Kategorija()
        {
            Kurs = new HashSet<Kurs>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        [Required]
        public string Naziv { get; set; }
        [StringLength(50)]
        [Required]
        public string Opis { get; set; }

        public virtual ICollection<Kurs> Kurs { get; set; }
    }
}
