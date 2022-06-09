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
    public class CiklusController : Controller
    {
        private readonly CoreDbContext _db;
        private readonly Authorize _authorize;

        public CiklusController(CoreDbContext db)
        {
            _db = db;
            _authorize = new Authorize(db);
        }

        public IActionResult Index()
        {
            if (_authorize.IsAuthorized())
            {
                var model = new CiklusIndexVM
                {
                    //Kurs=_db.Kurs.Select(x=> new SelectListItem { Value=x.Id.ToString(),Text=x.Naziv}).ToList()
                    Aktivni = _db.Ciklus.Where(x => x.JeZavrsen == false).Select(x => new CiklusIndexVM.Row
                    {
                        KursId = x.KursId,
                        Kurs = x.Kurs.Naziv,
                        PredavacKorisnickiRacunId=x.Kurs.Predavac.KorisnickiRacunId,
                        Predavac=x.Kurs.Predavac.Ime,
                        CiklusId = x.Id,
                        Naziv = x.Naziv,
                        JeZavrsen = x.JeZavrsen,
                        DatumPocetka = x.DatumPocetka.ToString(),
                        DatumZavrsetka = x.DatumKraja.ToString()
                    }).ToList(),
                    Neaktivni = _db.Ciklus.Where(x => x.JeZavrsen == true).Select(x => new CiklusIndexVM.Row
                    {
                        KursId = x.KursId,
                        Kurs = x.Kurs.Naziv,
                        PredavacKorisnickiRacunId = x.Kurs.Predavac.KorisnickiRacunId,
                        Predavac = x.Kurs.Predavac.Ime,
                        CiklusId = x.Id,
                        Naziv = x.Naziv,
                        JeZavrsen = x.JeZavrsen,
                        DatumPocetka = x.DatumPocetka.ToString(),
                        DatumZavrsetka = x.DatumKraja.ToString()
                    }).ToList()

                };
                return View("Index", model);
            }
            return BadRequest("Niste autorizovani!");
        }
        public IActionResult PrikaziPolaznik(int ciklusId)
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                var model = new PrikaziPolaznikVM
                {
                    Rows = _db.PolaznikCiklus.Where(x => x.CiklusId == ciklusId).Select(x => x.Polaznik).Select(y => new PrikaziPolaznikVM.Row
                    {
                        PolaznikId = y.Id,
                        Polaznik = y.Ime
                    }).ToList()
                };
                return View("PrikaziPolaznik", model);
            }
            return BadRequest("Niste autorizovani!");
        }
        public IActionResult IndexKurs(int kursId) // prikazuje cikluse za određeni kurs
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                var k = _db.Kurs.Find(kursId);
                var model = new KursCiklus
                {
                    KursId = kursId,
                    Kurs = k.Naziv,
                    Rows = _db.Ciklus.Where(x => x.KursId == kursId).Select(x => new KursCiklus.Row
                    {
                        CiklusId = x.Id,
                        Naziv = x.Naziv,
                        JeZavrsen = x.JeZavrsen,
                        DatumPocetka = x.DatumPocetka.ToString(),
                        DatumZavrsetka = x.DatumKraja.ToString()

                    })
                    .ToList()
                };
                return View("KursCiklus", model);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Dodaj(int kursId)
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                var k = _db.Kurs.Find(kursId);
                var model = new CiklusDodajUrediVM
                {
                    KursId = kursId,
                    Kurs = k.Naziv
                };
                return View("DodajUredi", model);
            }
            return BadRequest("Niste autorizovani!");
        } 
        
        public IActionResult UkloniPolaznik(int polaznikId, int ciklusId)
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                var pc = _db.PolaznikCiklus.Where(x => x.PolaznikId == polaznikId && x.CiklusId == ciklusId).FirstOrDefault();
                var c = _db.Ciklus.Find(ciklusId);
                _db.PolaznikCiklus.Remove(pc);
                _db.SaveChanges();
                return Redirect("IndexKurs?kursId=" + c.KursId);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Uredi(int kursId, int ciklusId)
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                Ciklus c = _db.Ciklus.Where(x => x.Id == ciklusId).FirstOrDefault();
                Kurs k = _db.Kurs.Find(kursId);

                var model = new CiklusDodajUrediVM
                {
                    KursId = kursId,
                    Kurs = k.Naziv,
                    CiklusId = ciklusId,
                    Naziv = c.Naziv,
                    JeZavrsen = c.JeZavrsen,
                    DatumPocetka = c.DatumPocetka,
                    DatumZavrsetka = c.DatumKraja
                };
                return View("DodajUredi", model);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Obrisi(int ciklusId, int kursId)
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                Ciklus c = _db.Ciklus.Find(ciklusId);
                _db.Ciklus.Remove(c);
                _db.SaveChanges();
                return Redirect("IndexKurs?kursId=" + kursId);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Detalji(int ciklusId)
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                var c = _db.Ciklus.Include(x => x.Kurs).Include(x=>x.Kurs.Predavac).Where(x => x.Id == ciklusId).FirstOrDefault();
                var model = new CiklusDetaljiVM
                {
                    CiklusId = ciklusId,
                    Ciklus = c.Naziv,
                    PredavacKorisnickiRacunId = c.Kurs.Predavac.KorisnickiRacunId,
                    KursId = c.KursId,
                    Kurs = c.Kurs.Naziv,
                    DatumPocetka = c.DatumPocetka.ToString(),
                    DatumZavrsetka = c.DatumKraja.ToString(),
                    Ocijenjeni = _db.PolaznikCiklus.Where(x => x.CiklusId == ciklusId && x.JeOcijenjen == true).Select(x => new CiklusDetaljiVM.Row
                    {
                        Id = x.Id,
                        PolaznikId = x.PolaznikId,
                        Polaznik = x.Polaznik.Ime,
                        Ocjena = x.KonacnaOcjena
                    }).ToList(),
                    Neocijenjeni = _db.PolaznikCiklus.Where(x => x.CiklusId == ciklusId && x.JeOcijenjen == false).Select(x => new CiklusDetaljiVM.Row
                    {
                        Id = x.Id,
                        PolaznikId = x.PolaznikId,
                        Polaznik = x.Polaznik.Ime
                    }).ToList()
                };

                return View(model);
            }
            return BadRequest("Niste autorizovani!");
        }
        public IActionResult Ocijeni(int polaznikCiklusId)
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                var pc = _db.PolaznikCiklus.Include(x => x.Polaznik).Include(x => x.Ciklus).Where(x => x.Id == polaznikCiklusId).FirstOrDefault();
                var model = new OcijeniPolaznikVM
                {
                    Id = polaznikCiklusId,
                    PolaznikId = pc.PolaznikId,
                    Polaznik = pc.Polaznik.Ime,
                    CiklusId = pc.CiklusId,
                    Ciklus = pc.Ciklus.Naziv
                };
                return View(model);
            }
            return BadRequest("Niste autorizovani!");
        }
        public IActionResult UrediOcjenu(int polaznikCiklusId)
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                var x = _db.PolaznikCiklus.Include(x => x.Ciklus).Include(x => x.Polaznik).Where(x => x.Id == polaznikCiklusId).FirstOrDefault();
                var model = new OcijeniPolaznikVM
                {
                    Id = polaznikCiklusId,
                    PolaznikId = x.PolaznikId,
                    Polaznik = x.Polaznik.Ime,
                    CiklusId = x.CiklusId,
                    Ciklus = x.Ciklus.Naziv,
                    Bodovi = x.Bodovi,
                    Ocjena = x.KonacnaOcjena
                };
                return View("Ocijeni", model);
            }
            return BadRequest("Niste autorizovani!");
        }
        public IActionResult ObrisiOcjenu(int polaznikCiklusId)
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                var x = _db.PolaznikCiklus.Where(x => x.Id == polaznikCiklusId).FirstOrDefault();
                x.JeOcijenjen = false;
                x.Bodovi = 0;
                x.KonacnaOcjena = 5;
                _db.SaveChanges();
                return Redirect("Detalji?ciklusId=" + x.CiklusId);
            }
            return BadRequest("Niste autorizovani!");
           
        }
        public IActionResult SnimiOcjenu(int Id, float Bodovi, int Ocjena)
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                PolaznikCiklus x = _db.PolaznikCiklus.Where(x => x.Id == Id).FirstOrDefault();
                if (x.JeOcijenjen == false)
                {
                    x.JeOcijenjen = true;
                }

                x.Bodovi = Bodovi;
                x.KonacnaOcjena = Ocjena;

                _db.SaveChanges();
                return Redirect("Detalji?ciklusId=" + x.CiklusId);
            }
            return BadRequest("Niste autorizovani!");
        }
        public IActionResult Snimi(int ciklusId, int KursId, string Naziv, bool JeZavrsen, DateTime DatumPocetka, DateTime DatumZavrsetka)
        {
            if(!ModelState.IsValid)
            {
                return Redirect("DodajUredi");
            }
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                Ciklus c;
                if (ciklusId == 0)
                {
                    c = new Ciklus();
                    _db.Ciklus.Add(c);
                }
                else
                {
                    c = _db.Ciklus.Find(ciklusId);
                }
                c.KursId = KursId;
                c.Naziv = Naziv;
                c.JeZavrsen = JeZavrsen;
                c.DatumPocetka = DatumPocetka;
                c.DatumKraja = DatumZavrsetka;

                _db.SaveChanges();
                return Redirect("IndexKurs?kursId=" + c.KursId);
            }
            return BadRequest("Niste autorizovani!");
        }
    }
}

