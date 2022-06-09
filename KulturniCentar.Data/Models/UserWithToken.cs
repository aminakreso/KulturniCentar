using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KulturniCentar.Data.Models
{
    public class UserWithToken
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        //public string Token { get; set; }
        public int KorisnickiRacunId { get; set; }
        public virtual KorisnickiRacun KorisnickiRacun { get; set; }

        //public UserWithToken(KorisnickiRacun korisnickiRacun)
        //{
        //    this.Id = Id;
        //    this.KorisnickoIme = korisnickiRacun.KorisnickoIme;
        //    this.Uloga = korisnickiRacun.Uloga;
        //}
    }
}
