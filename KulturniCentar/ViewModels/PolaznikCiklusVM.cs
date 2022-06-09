using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class PolaznikCiklusVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {
            public int Id { get; set; }
            public int PolaznikId { get; set; }
            public string Polaznik { get; set; }
            public int CiklusId { get; set; }
            public string Ciklus { get; set; }
            public bool JeOcijenjen { get; set; }
        }
        //public int Bodovi{ get; set; }
        //public int KonacnaOcjena{ get; set; }
    }
}
