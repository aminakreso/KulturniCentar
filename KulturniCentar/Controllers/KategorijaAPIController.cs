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

namespace KulturniCentar.Web.Controllers
{
    public class KategorijaAPIController : Controller
    {
        private readonly CoreDbContext _db;
        private readonly Authorize _authorize;

        public KategorijaAPIController(CoreDbContext db)
        {
            _db = db;
            _authorize = new Authorize(db);
        }
        public IActionResult Index(string q)
        {
            //if (_authorize.IsAuthorized())
            //{
                var model = new KategorijaPrikazVM()//prikaz za angular
                {
                    kategorije = _db.Kategorija
                    .Where(s => q == null || s.Naziv.StartsWith(q)).Select(x => new KategorijaPrikazVM.Row
                    {
                        id = x.Id,
                        naziv = x.Naziv,
                        opis = x.Opis,
                        brojKurseva = x.Kurs.Count()
                    }).ToList()
                };
                return Ok(model);
           // }
           // return BadRequest("Niste autorizovani!");
        }

        public IActionResult Obrisi(int id)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                Kategorija k = _db.Kategorija.Find(id);
                _db.Kategorija.Remove(k);
                _db.SaveChanges();
                return Ok();
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Dodaj()
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                var model = new Kategorija();
                return Ok();
            }
            return BadRequest("Niste autorizovani!");
        }
        public IActionResult Snimi([FromBody] KategorijaPrikazVM.Row x) //snimi za angular
        {
            Kategorija k;
            if (x.id == 0)
            {
                k = new Kategorija();
                _db.Kategorija.Add(k);
            }
            else
            {
                k = _db.Kategorija.Find(x.id);
            }
            k.Naziv = x.naziv;
            k.Opis = x.opis;
            _db.SaveChanges();
            return Ok();
        }
        public IActionResult Detalji(int id)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
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
