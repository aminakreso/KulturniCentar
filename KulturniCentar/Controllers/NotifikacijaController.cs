using KulturniCentar.Data.Models;
using KulturniCentar.Helper;
using KulturniCentar.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.Controllers
{
    public class NotifikacijaController : Controller
    {
        private readonly CoreDbContext _db;
        private readonly Authorize _authorize;

        public NotifikacijaController(CoreDbContext db)
        {
            _db = db;
            _authorize = new Authorize(db);
        }
        public IActionResult Index()
        {

            if (_authorize.IsAuthorized())
            {
                var model = new NotifikacijaIndexVM
                {
                    Rows = _db.Notifikacija.Select(x => new NotifikacijaIndexVM.Row
                    {
                        Id = x.Id,
                        Naslov = x.Naslov,
                        Datum = x.Datum.ToString(),
                        Sadrzaj = x.Sadrzaj,
                        KorisnickiRacunId = x.KorisnickiRacunId,
                        KorisnickoIme = x.KorisnickiRacun.KorisnickoIme,
                    }).ToList()
                };
                return View("Index", model);
            }
            return BadRequest("Niste autorizovani!");

            //return View("Index", model);
        }

        public IActionResult Dodaj()
        {
            if (_authorize.IsAuthorized() && ( _authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                var model = new NotifikacijaDodajUrediVM
                {
                    KorisnickiRacunId = 1, //treba uzet id od korisnika
                    KorisnickoIme = "Amina",
                    Kurs = _db.Kurs.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList()
                };
                return View("DodajUredi", model);
            }
            return BadRequest("Niste autorizovani!");
           
        }

        public IActionResult Uredi(int notifikacijaId)
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                Notifikacija n = _db.Notifikacija.Where(x => x.Id == notifikacijaId).FirstOrDefault();

                var model = new NotifikacijaDodajUrediVM
                {
                    Id = n.Id,
                    Naslov = n.Naslov,
                    Datum = n.Datum,
                    KorisnickiRacunId = 1,
                    KorisnickoIme = "AMinaa",
                    Sadrzaj = n.Sadrzaj,
                    Kurs = _db.Kurs.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList()
                };
                return View("DodajUredi", model);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Obrisi(int notifikacijaId)
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                Notifikacija n = _db.Notifikacija.Find(notifikacijaId);
                _db.Notifikacija.Remove(n);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest("Niste autorizovani!");
        }
        public IActionResult Snimi(int Id, string Naslov, DateTime Datum, string Sadrzaj, string KorisnickoIme, int KorisnickiRacunId,int KursId)
        {
            if (_authorize.IsAuthorized()  && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                Notifikacija n;
                if (Id == 0)
                {
                    n = new Notifikacija();
                    _db.Notifikacija.Add(n);
                }
                else
                {
                    n = _db.Notifikacija.Find(Id);
                }
                //n.Id = notifikacijaId;
                n.Naslov = Naslov;
                n.Sadrzaj = Sadrzaj;
                n.Datum = Datum;
                n.KorisnickiRacunId = KorisnickiRacunId;
                _db.SaveChanges();

                var x = _db.KursNotifikacija.Where(x => x.NotifikacijaId == n.Id && x.KursId == KursId).FirstOrDefault();
                if (x != null)
                {
                    x.KursId = KursId;
                }
                else
                {
                    _db.Add(new KursNotifikacija { NotifikacijaId = n.Id, KursId = KursId });
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest("Niste autorizovani!");

        }
    }
}
