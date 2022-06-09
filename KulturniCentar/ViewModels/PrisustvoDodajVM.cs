using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class PrisustvoDodajVM
    {
     
            public int PrisustvoId { get; set; }
            public int PolaznikId { get; set; }
            public string Polaznik { get; set; }
            public bool?  Prisutan{ get; set; }
            public int SusretId { get; set; }
            

    }
}
