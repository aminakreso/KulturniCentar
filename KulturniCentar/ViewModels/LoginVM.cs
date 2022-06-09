using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Korisnicko ime je obavezno!")]
        public string KorisnickoIme { get; set; }
        [Required]
        public string Lozinka { get; set; }

    }
}
