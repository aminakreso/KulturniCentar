using KulturniCentar.Data.Models;
using KulturniCentar.Helper;
using KulturniCentar.ViewModels;
using KulturniCentar.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.Controllers
{
    public class KategorijaController : Controller
    {
        private readonly CoreDbContext _db;
        private readonly Authorize _authorize;

        public KategorijaController(CoreDbContext db)
        {
            _db = db;
            _authorize = new Authorize(db);
        }
        public IActionResult Index()
        {
            if (_authorize.IsAuthorized())
            {
                var model = new KategorijaIndexVM()
                {
                    rows = _db.Kategorija.Select(x => new KategorijaIndexVM.Row
                    {
                        Id = x.Id,
                        Naziv = x.Naziv,
                        Opis = x.Opis,
                        BrojKurseva = x.Kurs.Count()
                    }).ToList()
                };
                return View("Index", model);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Obrisi(int id)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                Kategorija k = _db.Kategorija.Find(id);
                _db.Kategorija.Remove(k);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Dodaj()
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                var model = new Kategorija();
                return View("Dodaj", model);
            }
            return BadRequest("Niste autorizovani!");
        }
        public IActionResult Uredi(int Id)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                var model = _db.Kategorija.Find(Id);
                return View("Uredi", model);
            }
            return BadRequest("Niste autorizovani!");
        }
        public IActionResult Snimi(Kategorija x)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                Kategorija k;
                if (x.Id==0)
                {
                    k = new Kategorija();
                    _db.Kategorija.Add(k);
                }
                else
                {
                    k = _db.Kategorija.Find(x.Id);
                }
                k.Naziv = x.Naziv;
                k.Opis = x.Opis;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest("Niste autorizovani!");
        }
        public IActionResult Detalji(int id)
        {
            if (_authorize.IsAuthorized())
            {
                Kategorija x = _db.Kategorija.Where(k => k.Id == id)
                                         .Include(k => k.Kurs)
                                         .SingleOrDefault();

                var model = new KategorijaDetaljiVM()
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    Opis = x.Opis,
                    BrojKurseva = x.Kurs.Count()
                };
                return View("Detalji", model);
            }
            return BadRequest("Niste autorizovani!");
        }
    }
}
