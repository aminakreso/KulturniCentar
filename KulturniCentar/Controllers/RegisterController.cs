using KulturniCentar.Data.Models;
using KulturniCentar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.Controllers
{
    public class RegisterController : Controller
    {
        private readonly CoreDbContext _db;

        public RegisterController(CoreDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.Lozinka != model.LozinkaPotvrdi)
                { 
                    TempData["Poruka"] = "Nisu ispravni podaci za prijavu !";
                    return Redirect("/Home/Register");
                }
                var kR = _db.KorisnickiRacun.Where(x => x.KorisnickoIme == model.KorisnickoIme).FirstOrDefault();
                if(kR!=null)
                {
                    TempData["Poruka"] = "Korisnik vec postoji!";
                    return Redirect("/Home/Register");
                }
                var korisnickiRacun = new KorisnickiRacun
                {
                    KorisnickoIme = model.KorisnickoIme,
                    Lozinka = model.Lozinka,
                    Uloga = "Polaznik"

                };
                _db.KorisnickiRacun.Add(korisnickiRacun);
                _db.SaveChanges();

                var user = new Polaznik()
                {
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    Email = model.Email,
                    Telefon = model.Telefon,
                    KorisnickiRacunId = korisnickiRacun.Id
                };
                _db.Polaznik.Add(user);
                _db.SaveChanges();
                return Redirect("/Home/Login");

            }
            //ModelState.Clear();
            return Redirect("/Home/Register");
        }
    }
}
