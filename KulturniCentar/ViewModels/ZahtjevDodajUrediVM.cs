using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class ZahtjevDodajUrediVM
    {
        public int PolaznikId { get; set; }
        public string Polaznik { get; set; }
        public int ZahtjevId { get; set; }
        public string Naslov { get; set; }
        public string Napomena { get; set; }
        public int KursId  { get; set; }
        public DateTime? Datum{ get; set; }
        //public string IsPrihvacen { get; set; }
        public List<SelectListItem> Kurs { get; set; }

    }
}
