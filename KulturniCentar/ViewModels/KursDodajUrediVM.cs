using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class KursDodajUrediVM
    {
        public int KursId { get; set; }
        public string Naziv { get; set; }
        public int? MaxBrojPolaznika { get; set; }
        public int PredavacId { get; set; }
        public int KategorijaId { get; set; }
        public int MaterijalId { get; set; }

        public List<SelectListItem> Kategorije { get; set; }
        public List<SelectListItem> Predavaci { get; set; }
        public List<SelectListItem> Materijali { get; set; }


    }
}
