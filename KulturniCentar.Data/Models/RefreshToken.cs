using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace KulturniCentar.Data.Models
{
    public partial class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        //public int Id { get; set; }
        public int? KorisnickiRacunId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Token { get; set; }
        public KorisnickiRacun KorisnickiRacun { get; set; }
    }
}
