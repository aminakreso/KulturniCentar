using KulturniCentar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class MaterijaliIndexVM
    {
        public int SusretId { get; set; }
        public string Susret { get; set; }
        public List<Row> Rows { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
            public string Tip { get; set; }
            public DateTime Kreirano { get; set; }
            
        }
    }
}
