using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class PolaznikDodajUrediVM
    {
     
            public int PolaznikId { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Email { get; set; }
            public string Telefon { get; set; }
            public int KorisnickiRacunId { get; set; }
            public int? UspjehId { get; set; }
            public double? Uspjeh { get; set; }
            public List<SelectListItem> KorisnickiRacun { get; set; }
            public IFormFile Slika { get; set; }
            public string Route { get; set; }


    }
}
