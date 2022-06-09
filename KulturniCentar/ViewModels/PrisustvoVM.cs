using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class PrisustvoVM
    {
        public List<Row> rows { get; set; }

        public int SusretId { get; set; }
        public string Susret { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public int PolaznikId { get; set; }
            public string Polaznik { get; set; }

            public bool? Prisutan { get; set; }


        }
    }
}
