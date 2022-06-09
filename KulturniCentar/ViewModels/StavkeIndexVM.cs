using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class StavkeIndexVM
    {
        public int KategorijaID { get; set; }
        public List<Row> rows { get; set; }

        public class Row
        {
            public string Naziv { get; set; }
            public int? MaxBrojPolaznika { get; set; }
            public string Predavac { get; set; }
            //public string Materijali { get; set; }
            public int KursId { get; set; }
        }
    }
}
