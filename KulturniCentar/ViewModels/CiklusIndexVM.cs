using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class CiklusIndexVM
    {
        public List<Row> Aktivni { get; set; }
        public List<Row> Neaktivni { get; set; }

        public class Row
        {
            public int KursId { get; set; }
            public string Kurs { get; set; }
            public int PredavacKorisnickiRacunId { get; set; }
            public string Predavac { get; set; }
            public int CiklusId { get; set; }
            public string Naziv { get; set; }
            public bool? JeZavrsen { get; set; }
            public string DatumPocetka { get; set; }
            public string DatumZavrsetka { get; set; }
        }
    }
}
