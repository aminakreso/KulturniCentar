using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class CiklusDetaljiVM
    {
        public int CiklusId { get; set; }
        public string Ciklus { get; set; }
        public int PredavacKorisnickiRacunId { get; set; }
        public int KursId { get; set; }
        public string Kurs { get; set; }
        public string DatumPocetka { get; set; }
        public string DatumZavrsetka { get; set; }
        public List<Row> Neocijenjeni { get; set; }
        public List<Row> Ocijenjeni { get; set; }

        public class Row
        {
            public int Id { get; set; }
            public int PolaznikId { get; set; }
            public string Polaznik { get; set; }
            public int? Ocjena { get; set; }

        }
    }
}
