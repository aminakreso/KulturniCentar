using KulturniCentar.Data.Models;
using KulturniCentar.Helper;
using KulturniCentar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.Controllers
{
    public class SusretController : Controller
    {
        private readonly CoreDbContext _db;
        private readonly Authorize _authorize;

        public SusretController(CoreDbContext db)
        {
            _db = db;
            _authorize = new Authorize(db);
        }
        public IActionResult IndexCiklus(int ciklusId) // susreti za određeni ciklus
        {
            if (_authorize.IsAuthorized() )
            {
                var c = _db.Ciklus.Include(x=>x.Kurs.Predavac).Where(x=>x.Id==ciklusId).FirstOrDefault();
                var model = new CiklusSusretVM
                {
                    CiklusId = ciklusId,
                    Ciklus = c.Naziv,
                    PredavacKorisnickiRacunId=c.Kurs.Predavac.KorisnickiRacunId,
                    Rows = _db.Susret.Where(x => x.CiklusId == ciklusId).Select(x => new CiklusSusretVM.Row
                    {
                        SusretId = x.Id,
                        Naziv = x.Naziv,
                        Datum = x.Datum.ToString()

                    })
                    .ToList()
                };
                return View("CiklusSusret", model);
            }
            return BadRequest("Niste autorizovani!");
        }
        public IActionResult Dodaj(int ciklusId)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                var c = _db.Ciklus.Find(ciklusId);
                var model = new SusretDodajUrediVM
                {
                    CiklusId = ciklusId,
                    Ciklus = c.Naziv
                };
                return View("DodajUredi", model);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Uredi(int ciklusId, int susretId)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                Ciklus c = _db.Ciklus.Where(x => x.Id == ciklusId).FirstOrDefault();
                Susret s = _db.Susret.Find(susretId);

                var model = new SusretDodajUrediVM
                {
                    CiklusId = ciklusId,
                    Ciklus = c.Naziv,
                    SusretId = susretId,
                    Naziv = s.Naziv,
                    Datum = s.Datum
                };
                return View("DodajUredi", model);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Obrisi(int ciklusId, int susretId)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                Susret s = _db.Susret.Find(susretId);
                _db.Susret.Remove(s);
                _db.SaveChanges();
                return Redirect("IndexCiklus?ciklusId=" + ciklusId);
            }
            return BadRequest("Niste autorizovani!");
        }
        public IActionResult Snimi(int CiklusId, int susretId, string Naziv, DateTime Datum)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                Susret x;
                if (susretId == 0)
                {
                    x = new Susret();
                    _db.Susret.Add(x);
                }
                else
                {
                    x = _db.Susret.Find(susretId);
                }
                x.CiklusId = CiklusId;
                x.Naziv = Naziv;
                x.Datum = Datum;

                _db.SaveChanges();
                return Redirect("IndexCiklus?ciklusId=" + CiklusId);
            }
            return BadRequest("Niste autorizovani!");
        }
        //public IActionResult DodajPrisustvo(int susretId, int ciklusId)
        //{
        //    Susret s = _db.Susret.Find(susretId);
        //    Ciklus c = _db.Ciklus.Find(ciklusId);

        //    var model = new PrisustvoSusretVM
        //    {
        //        CiklusId=ciklusId,
        //        Ciklus=c.Naziv,
        //        SusretId=susretId,
        //        Susret=s.Naziv,
        //        Rows= _db.PolaznikCiklus.Where(x=>x.CiklusId==ciklusId).Select(x=>x.Polaznik).Select(x=> new PrisustvoSusretVM.Row
        //        {
        //            PolaznikId = x.Id,
        //            Polaznik = x.Ime,
        //            PrisustvoId=x.Prisustvo
        //        }).ToList()
        //    };
        //    return View(model);
        //}

        public IActionResult DodajPrisustvo(int SusretId)
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                Susret s = _db.Susret.Include(x => x.Ciklus).Where(x => x.Id == SusretId).FirstOrDefault();
                var model = new PrisustvoSusretVM
                {
                    CiklusId = s.CiklusId,
                    Ciklus = s.Ciklus.Naziv,
                    SusretId = SusretId,
                    Susret = s.Naziv,
                    Rows = _db.Prisustvo.Select(x => new PrisustvoSusretVM.Row
                    {
                        PrisustvoId = x.Id,
                        PolaznikId = x.PolaznikId,
                        Polaznik = x.Polaznik.Ime,
                        Prisutan = x.Prisutan,

                    }).ToList()
                };
                return View("DodajPrisustvo", model);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult JePrisutan(int polaznikId, int susretId)
        {
            
            //var prisutan = _db.Polaznik.Where(x => x.Id == polaznikId).FirstOrDefault();
            var prisustvo = _db.Prisustvo.Where(x => x.PolaznikId == polaznikId && x.SusretId==susretId).FirstOrDefault();

            prisustvo.Prisutan = true;
            _db.Prisustvo.Update(prisustvo);
            _db.SaveChanges();

            return RedirectToAction("DodajPrisustvo", new { SusretId = susretId });
        }
        public IActionResult NijePrisutan(int polaznikId, int susretId, int _ciklusId)
        {
            var prisustvo = _db.Prisustvo.Where(x => x.PolaznikId == polaznikId && x.SusretId == susretId).FirstOrDefault();
            prisustvo.Prisutan = false;
            _db.Prisustvo.Update(prisustvo);
            _db.SaveChanges();

            return RedirectToAction("DodajPrisustvo", new { SusretId = susretId });

        }
        //public IActionResult SnimiPrisustvo(int PolaznikId, bool Prisutan )
        //{

        //}
    }
}
