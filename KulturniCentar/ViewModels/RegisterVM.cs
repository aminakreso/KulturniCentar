using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="Obavezno polje")]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public string KorisnickoIme { get; set; }
        [Required]
        public string Lozinka { get; set; }
        [Required]
        public string LozinkaPotvrdi { get; set; }

    }
}
