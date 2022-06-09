using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KulturniCentar.Data.Models
{
    [Table("Zahtjev")]
    public partial class Zahtjev
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Naslov { get; set; }
        [StringLength(200)]
        public string Napomena { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Datum { get; set; }
        public int KursId { get; set; }
        public int AdminId { get; set; }
        public int PolaznikId { get; set; }

        public bool IsZavrsen { get; set; }
        public virtual Admin Admin { get; set; }
    
        public virtual Kurs Kurs { get; set; }
      
        public virtual Polaznik Polaznik { get; set; }
    }
}
