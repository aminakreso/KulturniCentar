using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class KategorijaIndexVM
    {
        public List<Row> rows { get; set; }
        public class Row
        {
            public int Id { get; set; }

            public string Naziv { get; set; }
            public string Opis { get; set; }
            public int BrojKurseva { get; set; }
        }

    }
}
