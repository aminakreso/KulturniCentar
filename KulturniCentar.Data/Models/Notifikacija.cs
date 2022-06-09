using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KulturniCentar.Data.Models
{
    [Table("Notifikacija")]
    public partial class Notifikacija
    {

        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Naslov { get; set; }
        [StringLength(200)]
        public string Sadrzaj { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Datum { get; set; }
        public int KorisnickiRacunId { get; set; }

        public virtual KorisnickiRacun KorisnickiRacun { get; set; }
       
        public List<KursNotifikacija> KursNotifikacija { get; set; }
    }
}
