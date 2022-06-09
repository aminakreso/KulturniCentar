using KulturniCentar.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class PredavacDodajUrediVM
    {
        public int PredavacId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int KorisnickiRacunId { get; set; }
        public string KorisnickoIme{ get; set; }
        public string Lozinka{ get; set; }

    }
}
