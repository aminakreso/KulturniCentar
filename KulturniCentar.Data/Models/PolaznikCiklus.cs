using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KulturniCentar.Data.Models
{
    public class PolaznikCiklus
    {
        public int Id { get; set; }
        public int PolaznikId { get; set; }
        public int CiklusId { get; set; }
        public bool JeOcijenjen { get; set; }
        //public int OcjenaId { get; set; }
        //public virtual Ocjena Ocjena { get; set; }
        public virtual Ciklus Ciklus { get; set; }
        public virtual Polaznik Polaznik{ get; set; }
        public double? Bodovi { get; set; }
        public int? KonacnaOcjena { get; set; }

    }
}
