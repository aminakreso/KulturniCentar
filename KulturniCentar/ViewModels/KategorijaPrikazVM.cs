using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.Web.ViewModels
{
    public class KategorijaPrikazVM //vm za angular
    {
        public class Row
        {
            public int id { get; set; }

            public string naziv { get; set; }
            public string opis { get; set; }
            public int brojKurseva { get; set; }
        }
        public List<Row> kategorije { get; set; }
        public string q { get; set; }
    }
}
