using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KulturniCentar.Data.Models
{
    [Table("Materijali")]
    public partial class Materijali
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public byte[] DataFiles { get; set; }
        public DateTime Kreirano { get; set; }
        public int SusretId { get; set; }
        public virtual Susret Susret { get; set; }

    }
}
