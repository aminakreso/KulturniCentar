using KulturniCentar.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.Helper
{
    public class Authorize
    {
        private readonly CoreDbContext _db;
        public Authorize(CoreDbContext db)
        {
            _db = db;
        }
        public bool IsAuthorized()
        {
            return _db.UserWithToken.Where(x => x.KorisnickiRacunId == Global.KorisnickiRacunId && x.AccessToken == Global.Token).Any();
        }
        public bool IsAdmin()
        {
            return _db.UserWithToken.Include(x=>x.KorisnickiRacun).Where(x => x.KorisnickiRacunId == Global.KorisnickiRacunId && Global.Role == "Admin").Any();
        }
        public bool IsPredavac()
        {
            return _db.UserWithToken.Include(x => x.KorisnickiRacun).Where(x => x.KorisnickiRacunId == Global.KorisnickiRacunId && x.KorisnickiRacun.Uloga == "Predavac").Any();
        }
        public bool IsPolaznik()
        {
            return _db.UserWithToken.Include(x => x.KorisnickiRacun).Where(x => x.KorisnickiRacunId == Global.KorisnickiRacunId && x.KorisnickiRacun.Uloga == "Polaznik").Any();
        }
    }
}
