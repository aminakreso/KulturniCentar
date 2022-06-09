using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class NotifikacijaIndexVM
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int Id { get; set; }
            public string Naslov { get; set; }
            public string Sadrzaj { get; set; }
            public string Datum { get; set; }
            public int KorisnickiRacunId { get; set; }
            public string KorisnickoIme { get; set; }
            public int KursId { get; set; }
            public string Kurs { get; set; }

        }
    }
}
