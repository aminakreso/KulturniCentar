using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class OcijeniPolaznikVM
    {
        public int Id { get; set; }
        public int PolaznikId { get; set; }
        public string Polaznik { get; set; }
        public int CiklusId { get; set; }
        public string Ciklus { get; set; }
        public double? Bodovi { get; set; }
        public int? Ocjena { get; set; }

    }
}
