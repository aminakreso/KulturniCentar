using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KulturniCentar.Data.Models
{
    [Table("KursNotifikacija")]
    public partial class KursNotifikacija
    {
        [Key]
        public int Id { get; set; }
        public int KursId { get; set; }
        public int NotifikacijaId { get; set; }

        public virtual Kurs Kurs { get; set; }
  
        public virtual Notifikacija Notifikacija { get; set; }
    }
}
