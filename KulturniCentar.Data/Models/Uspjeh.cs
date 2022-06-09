using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KulturniCentar.Data.Models
{
    [Table("Uspjeh")]
    public partial class Uspjeh
    {
        [Key]
        public int Id { get; set; }
        public double? Prosjek { get; set; }
        public int? Percentile { get; set; }
        //public int PolaznikId { get; set; }
        //public virtual Polaznik Polaznik { get; set; }
    }
}
