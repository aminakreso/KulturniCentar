using KulturniCentar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class PredavacIndexVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {
            public int Id { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Email { get; set; }
            public string Telefon { get; set; }
            public int KorisnickiRacunId { get; set; }
            public string korisnickoIme { get; set; }
           
        }
    }
}
