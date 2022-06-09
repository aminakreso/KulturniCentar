using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class PrisustvoSusretVM
    {
        public int CiklusId { get; set; }
        public string Ciklus{ get; set; }
        public int SusretId { get; set; }
        public string Susret { get; set; }

        public List<Row> Rows { get; set; }

        public class Row
        {
            public int PrisustvoId { get; set; }
            public int PolaznikId { get; set; }
            public string Polaznik { get; set; }
            public bool? Prisutan { get; set; }

        }
    }
}
