using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class SusretDodajUrediVM
    {
        public int CiklusId { get; set; }
        public string Ciklus { get; set; }
        public int SusretId { get; set; }
        public string Naziv { get; set; }
        public DateTime? Datum { get; set; }

    }
}
