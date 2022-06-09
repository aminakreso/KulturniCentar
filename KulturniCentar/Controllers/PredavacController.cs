using KulturniCentar.Data.Models;
using KulturniCentar.Helper;
using KulturniCentar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.Controllers
{
    public class PredavacController : Controller
    {
        private readonly CoreDbContext _db;
        private readonly Authorize _authorize;

        public PredavacController(CoreDbContext db)
        {
            _db = db;
            _authorize = new Authorize(db);
        }
        public IActionResult Index()
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin()||_authorize.IsPredavac()))
            {
                var model = new PredavacIndexVM
                {
                    rows = _db.Predavac.Select(x => new PredavacIndexVM.Row
                    {
                        Id = x.Id,
                        Ime = x.Ime,
                        Prezime = x.Prezime,
                        Email = x.Email,
                        KorisnickiRacunId = x.KorisnickiRacunId,
                        Telefon = x.Telefon,
                        korisnickoIme = x.KorisnickiRacun.KorisnickoIme
                    }).ToList()
                };
                return View("Index", model);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Dodaj()
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin() )
            {
                var model = new PredavacDodajUrediVM();
                return View("DodajUredi", model);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Uredi(int predavacId)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                Predavac p = _db.Predavac.Include(x => x.KorisnickiRacun).Where(x => x.Id == predavacId).FirstOrDefault();

                var model = new PredavacDodajUrediVM
                {
                    PredavacId = p.Id,
                    Ime = p.Ime,
                    Prezime = p.Prezime,
                    Email = p.Email,
                    Telefon = p.Telefon,
                    KorisnickiRacunId = p.KorisnickiRacunId,
                    KorisnickoIme = p.KorisnickiRacun.KorisnickoIme,
                    Lozinka = p.KorisnickiRacun.Lozinka
                };
                return View("DodajUredi", model);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Obrisi(int predavacId)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                Predavac p = _db.Predavac.Find(predavacId);
                _db.Predavac.Remove(p);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest("Niste autorizovani!");
        }
        public IActionResult Snimi(int PredavacId, string Ime, string Prezime, string Email, string Telefon, int KorisnickiRacunId, string KorisnickoIme,string Lozinka )
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                Predavac p;
                KorisnickiRacun k;
                if (KorisnickiRacunId == 0)
                {
                    k = new KorisnickiRacun();
                    _db.KorisnickiRacun.Add(k);
                }
                else
                {
                    k = _db.KorisnickiRacun.Find(KorisnickiRacunId);
                }

                //k.Id = KorisnickiRacunId;
                k.KorisnickoIme = KorisnickoIme;
                k.Lozinka = Lozinka;
                k.Uloga = "Predavac";
                _db.SaveChanges();
                if (PredavacId == 0)
                {
                    p = new Predavac();
                    _db.Predavac.Add(p);
                }
                else
                {
                    p = _db.Predavac.Find(PredavacId);
                }
                //p.Id = PredavacId;
                p.Ime = Ime;
                p.Prezime = Prezime;
                p.Email = Email;
                p.Telefon = Telefon;
                p.KorisnickiRacunId = k.Id;

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest("Niste autorizovani!");
        }
    }
}
