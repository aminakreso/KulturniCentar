using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class StavkeDodajVM
    {
            public string Naziv { get; set; }
            public int MaxBroj { get; set; }
            public List<SelectListItem> Predavaci { get; set; }
        public int PredavacId { get; set; }
        public int KursId { get; set; }
        public int KategorijaId { get; set; }



    }
}
