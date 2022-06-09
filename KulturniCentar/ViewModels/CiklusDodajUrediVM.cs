using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class CiklusDodajUrediVM
    {
        public int KursId { get; set; }
        public string Kurs { get; set; }
        public int CiklusId { get; set; }
        public string Naziv { get; set; }
        public bool JeZavrsen { get; set; }
        public DateTime? DatumPocetka { get; set; }
        public DateTime? DatumZavrsetka { get; set; }

    }
}
