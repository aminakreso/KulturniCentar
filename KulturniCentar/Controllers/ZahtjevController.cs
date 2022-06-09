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
    public class ZahtjevController : Controller
    {
        private readonly CoreDbContext _db;
        private readonly Authorize _authorize;

        public ZahtjevController(CoreDbContext db)
        {
            _db = db;
            _authorize = new Authorize(db);
        }

        //implementirati prosljedivanje polaznika

        public IActionResult Index(int KursId=1, int PolaznikId=2)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin() )
            {
                var p = _db.Polaznik.Find(PolaznikId);
                var model = new ZahtjevIndexVM
                {

                    Aktivni = _db.Zahtjev.Where(x => x.KursId == KursId && x.IsZavrsen == false).Select(x => new ZahtjevIndexVM.Row
                    {
                        PolaznikId = PolaznikId,
                        Polaznik = p.Ime,
                        ZahtjevId = x.Id,
                        KursId = x.KursId,
                        Kurs = x.Kurs.Naziv,
                        Naslov = x.Naslov,
                        Napomena = x.Napomena,
                        Datum = x.Datum,
                        IsPrihvacen = x.IsZavrsen
                    }).ToList(),
                    Neaktivni = _db.Zahtjev.Where(x => x.KursId == KursId && x.IsZavrsen == true).Select(x => new ZahtjevIndexVM.Row
                    {
                        PolaznikId = PolaznikId,
                        Polaznik = p.Ime,
                        ZahtjevId = x.Id,
                        KursId = x.KursId,
                        Kurs = x.Kurs.Naziv,
                        Naslov = x.Naslov,
                        Napomena = x.Napomena,
                        Datum = x.Datum,
                        IsPrihvacen = x.IsZavrsen
                    }).ToList()
                };
                return View("Index", model);
            }
            return BadRequest("Niste autorizovani!");
        }

        //implementirati prosljedivanje polaznika
        public IActionResult Dodaj(int ZahtjevId)
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                var z = _db.Zahtjev.Where(x => x.Id == ZahtjevId).FirstOrDefault();
                z.IsZavrsen = true;

                var c = _db.Ciklus.Include(x => x.Kurs).Where(x => x.KursId == z.KursId && x.JeZavrsen == false).FirstOrDefault();
                var p = _db.Polaznik.Where(x => x.Id == z.PolaznikId).FirstOrDefault();
                var pc = _db.PolaznikCiklus.Where(x => x.CiklusId == c.Id).ToList();

                var model = new PolaznikCiklus();
                if (pc.Count() < c.Kurs.MaxBrojPolaznika)
                {

                    model.CiklusId = c.Id;
                    model.PolaznikId = p.Id;
                    model.JeOcijenjen = false;

                }
                if (model != null)
                {
                    _db.PolaznikCiklus.Add(model);
                    _db.SaveChanges();
                }

                return Redirect("Index");
            }
            return BadRequest("Niste autorizovani!");

            //var model = new ZahtjevDodajUrediVM
            //{
            //    PolaznikId = PolaznikId,
            //    Polaznik = z.Ime,
            //    Kurs=_db.Kurs.Select(x=> new SelectListItem { Value=x.Id.ToString(), Text=x.Naziv}).ToList()
            //};
            //return View("DodajUredi", model);
        }

        //implementirati prosljedivanje polaznika

        //public IActionResult Uredi( int ZahtjevId, int PolaznikId = 2)
        //{
        //    Polaznik p = _db.Polaznik.Where(x => x.Id == PolaznikId).FirstOrDefault();
        //  //  Kurs k = _db.Kurs.Find(KursId);
        //    Zahtjev z = _db.Zahtjev.Find(ZahtjevId);

        //    var model = new ZahtjevDodajUrediVM
        //    {
        //        ZahtjevId=ZahtjevId,
        //        PolaznikId=PolaznikId,
        //        KursId=z.KursId,
        //        Kurs = _db.Kurs.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList(),
        //        Naslov = z.Naslov,
        //        Napomena=z.Napomena,
        //        Datum=z.Datum,
        //    };
        //    return View("DodajUredi", model);
        //}

        public IActionResult Obrisi(int ZahtjevId)
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                Zahtjev z = _db.Zahtjev.Find(ZahtjevId);
                _db.Zahtjev.Remove(z);
                _db.SaveChanges();
                return Redirect("Index?ZahtjevId=" + ZahtjevId);
            }
            return BadRequest("Niste autorizovani!");
        }
        public IActionResult Snimi(int ZahtjevId, int KursId, string Naslov, string Napomena, DateTime Datum, int PolaznikId=2)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin() )
            {
                Zahtjev z;
                if (ZahtjevId == 0)
                {
                    z = new Zahtjev();
                    _db.Zahtjev.Add(z);
                }
                else
                {
                    z = _db.Zahtjev.Find(ZahtjevId);
                }
                z.KursId = KursId;
                z.Naslov = Naslov;
                z.Napomena = Napomena;
                z.Datum = Datum;
                z.PolaznikId = PolaznikId;
                z.AdminId = 2;
                // implementirati admina
                _db.SaveChanges();
                return Redirect("Index?ZahtjevId=" + ZahtjevId);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult DodajZahtjev (int kursId, int polaznikId) {

            if (_authorize.IsAuthorized() && _authorize.IsPolaznik() )
            {
                var model = new ZahtjevDodajUrediVM
                {
                    PolaznikId = polaznikId,
                    KursId = kursId,
                    Naslov = "bla",
                    Datum = DateTime.Now,
                    Kurs = _db.Kurs.Where(x => x.Id == kursId).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList()

                };
                return PartialView("DodajUredi", model);
            }
            return BadRequest("Niste autorizovani!");
        
        }

        //public IActionResult SnimiZahtjev(ZahtjevDodajUrediVM x)
        //{
        //    Zahtjev z;
        //    if (x.ZahtjevId == 0)
        //    {
        //        z = new Zahtjev();
        //        _db.Zahtjev.Add(z);
        //    }
        //    else
        //    {
        //        z = _db.Zahtjev.Find(x.ZahtjevId);

        //    }
        //    z.PolaznikId = x.PolaznikId;
        //    z.KursId = x.KursId;
        //    z.Napomena = x.Napomena;
        //    z.Naslov = x.Naslov;
        //    z.Datum = x.Datum;
        //    z.IsZavrsen = true;
        //    _db.SaveChanges();

        //    return Redirect("Index");
        //}
    }
}

