using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KulturniCentar.Data.Models
{
    [Table("Ciklus")]
    public partial class Ciklus
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int KursId { get; set; }
        public virtual Kurs Kurs { get; set; }

        //public List<Polaznik> Polaznici { get; set; }
        public List<Susret> Susreti { get; set; }

        [Column("jeZavrsen")]
        public bool JeZavrsen { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DatumPocetka { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DatumKraja { get; set; }

        public List<PolaznikCiklus> PolaznikCiklus { get; set; }
    }
}
