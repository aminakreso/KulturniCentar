using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class KursIndexVM
    {
        public List<Row>rows { get; set; }

        public class Row
        {
            public int KursId { get; set; }
            public string Naziv { get; set; }
            public int? MaxBrojPolaznika { get; set; }
            public string Kategorija { get; set; }
            public string Predavac { get; set; }

        }
    }
}
