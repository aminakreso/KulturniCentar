using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KulturniCentar.Data.Models
{
    [Table("Susret")]
    public partial class Susret
    {
        //public Susret()
        //{
        //    Pohadjanje = new HashSet<Ciklus>();
        //}

        [Key]
        public int Id { get; set; }
        public int CiklusId { get; set; }
        public virtual Ciklus Ciklus { get; set; }
        public string Naziv { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Datum { get; set; }
        public List<Prisustvo> Prisustvo { get; set; }
        public List<Materijali> Materijali { get; set; }

        //public virtual ICollection<Ciklus> Pohadjanje { get; set; }
    }
}
