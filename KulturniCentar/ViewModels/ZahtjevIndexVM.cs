using KulturniCentar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class ZahtjevIndexVM
    {
        public List<Row> Aktivni { get; set; }
        public List<Row> Neaktivni { get; set; }

        public class Row
        {
            public int PolaznikId { get; set; }
            public string Polaznik { get; set; }
            public int ZahtjevId { get; set; }
            public int KursId { get; set; }
            public string Kurs { get; set; }
            public string Naslov { get; set; }
            public string Napomena { get; set; }
            public bool IsPrihvacen { get; set; }

            public DateTime? Datum { get; set; }
            
        }
    }
}
