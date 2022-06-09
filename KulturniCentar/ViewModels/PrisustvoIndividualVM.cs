using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class PrisustvoIndividualVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {
            public string Kurs { get; set; }
            public int KursId { get; set; }          
            public float  Prisutan { get; set; } // ukupno prisustvo
        }
    }
}
