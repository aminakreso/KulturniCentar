using KulturniCentar.Data.Models;
using KulturniCentar.Helper;
using KulturniCentar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.Controllers
{
    public class KursController : Controller
    {
        private readonly CoreDbContext _db;
        private readonly Authorize _authorize;

        public KursController(CoreDbContext db)
        {
            _db = db;

            _authorize = new Authorize(db);
        }
        public IActionResult Index()
        {
            if (_authorize.IsAuthorized())
            {
                var model = new KursIndexVM()
                {
                    rows = _db.Kurs.Select(x => new KursIndexVM.Row
                    {
                        Naziv = x.Naziv,
                        MaxBrojPolaznika = x.MaxBrojPolaznika,
                        Kategorija = x.Kategorija.Naziv,
                        Predavac = x.Predavac.Ime,
                        KursId = x.Id
                    }).ToList()
                };
                return View("Index", model);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Dodaj()
        {

            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                var ulazniModel = new KursDodajUrediVM();
                ulazniModel.KursId = 0;
                ulazniModel.Predavaci = _db.Predavac
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Ime
                    }).ToList();

                ulazniModel.Kategorije = _db.Kategorija
                     .Select(x => new SelectListItem
                     {
                         Value = x.Id.ToString(),
                         Text = x.Naziv
                     }).ToList();
                return View("DodajUredi", ulazniModel);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Snimi(int kursId,int KategorijaId,string naziv,int maxBrojPolaznika,int PredavacId,int MaterijalId)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                Kurs x;
                if (kursId == 0)
                {
                    x = new Kurs();
                    _db.Kurs.Add(x);
                }
                else
                {
                    x = _db.Kurs.Find(kursId);
                }
                x.Id = kursId;
                x.Naziv = naziv;
                x.MaxBrojPolaznika = maxBrojPolaznika;
                x.KategorijaId = KategorijaId;
                x.PredavacId = PredavacId;
                //x.MaterijaliId = MaterijalId;

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Obrisi(int kursId)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                Kurs k = _db.Kurs.Find(kursId);
                _db.Kurs.Remove(k);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Uredi(int kursId)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                Kurs k = _db.Kurs.Find(kursId);

                //trebat ce biti implementirano preko VM-a kursDetalji/kursEdit, ali treba i povuci selectovanu
                //vrijednost liste, trenutno implentirano kao readonly detalji
                KursDodajUrediVM model = new KursDodajUrediVM
                {
                    KursId = kursId,
                    Naziv = k.Naziv,
                    MaxBrojPolaznika = k.MaxBrojPolaznika,
                    Predavaci = _db.Predavac.Select(w => new SelectListItem
                    {
                        Value = w.Id.ToString(),
                        Text = w.Ime + " " + w.Prezime
                    }).ToList(),
                    Kategorije = _db.Kategorija.Select(k => new SelectListItem
                    {
                        Value = k.Id.ToString(),
                        Text = k.Naziv
                    }).ToList(),
                    Materijali = _db.Materijali.Select(m => new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = m.Naziv
                    }).ToList()
                };
                return View("DodajUredi", model);
            }
            return BadRequest("Niste autorizovani!");
        }
    }
}
