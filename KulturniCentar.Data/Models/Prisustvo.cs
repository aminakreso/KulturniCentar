using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KulturniCentar.Data.Models
{
    [Table("Prisustvo")]
    public partial class Prisustvo
    {

        [Key]
        public int Id { get; set; }
        public int PolaznikId { get; set; }
        public int SusretId { get; set; }
        public bool? Prisutan { get; set; }

        public virtual Polaznik Polaznik { get; set; }
        public virtual Susret Susret { get; set; }
    }
}
