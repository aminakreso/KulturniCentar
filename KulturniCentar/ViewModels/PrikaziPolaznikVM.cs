using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class PrikaziPolaznikVM
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int PolaznikId { get; set; }

            public string Polaznik { get; set; }
        }
    }
}
