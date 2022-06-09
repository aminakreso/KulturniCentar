using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class CiklusSusretVM
    {
        public int CiklusId { get; set; }
        public string Ciklus { get; set; }
        public List<Row> Rows { get; set; }
        public int PredavacKorisnickiRacunId { get; set; }

        public class Row
        {
            public int SusretId { get; set; }
            public string Datum { get; set; }
            public string Naziv { get; set; }
        }
    }
}
