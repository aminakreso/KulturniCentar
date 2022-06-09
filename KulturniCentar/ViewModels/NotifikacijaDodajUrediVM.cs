using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class NotifikacijaDodajUrediVM
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime? Datum { get; set; }
        public int KorisnickiRacunId { get; set; }
        public string KorisnickoIme { get; set; }
        public int KursId { get; set; }
        public List<SelectListItem> Kurs { get; set; }
    }
}
