using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.ViewModels
{
    public class ImageVM
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Sadrzaj { get; set; }
        public byte[] Slika { get; set; }
    }
}
