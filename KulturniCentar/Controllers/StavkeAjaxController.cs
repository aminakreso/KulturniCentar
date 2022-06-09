
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KulturniCentar.Data;
using KulturniCentar.ViewModels;
using KulturniCentar.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Web.Controllers
{
    public class StavkeAjaxController : Controller
    {
        private CoreDbContext _db;

        public StavkeAjaxController(CoreDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int kategorijaId)
        {
            StavkeIndexVM model = new StavkeIndexVM
            {
                KategorijaID = kategorijaId,
                rows = _db.Kurs.Where(x => x.KategorijaId == kategorijaId)
                .Select(s => new StavkeIndexVM.Row
                {
                    Naziv = s.Naziv,
                    MaxBrojPolaznika = s.MaxBrojPolaznika,
                    Predavac = s.Predavac.Ime,
                    KursId = s.Id
                }).ToList()
            };
            return PartialView(model);
        }

        public IActionResult Obrisi(int kursId)
        {
            Kurs x = _db.Kurs.Find(kursId);
            int kId = x.KategorijaId;
            _db.Kurs.Remove(x);
            _db.SaveChanges();
            return Redirect("/Kategorija/Detalji?id=" + kId);
            //      return RedirectToAction("Index");
            //return RedirectToAction("Detalji", "Kategorija", new {id=kId});

        }

        public IActionResult Uredi(int kursId)
        {

            Kurs x = _db.Kurs.Find(kursId);


            StavkeDodajVM model = new StavkeDodajVM
            {
                KategorijaId=x.KategorijaId,
                KursId=kursId,
                Naziv = x.Naziv,
                MaxBroj =(int) x.MaxBrojPolaznika,
                Predavaci = _db.Predavac.Select(w => new SelectListItem
                {
                    Value = w.Id.ToString(),
                    Text = w.Ime
                }).ToList()
            };

            return PartialView("Dodaj", model);
        }

        public IActionResult Dodaj(int kategorijaId)
        {
            Kategorija kat =_db.Kategorija.Find(kategorijaId);
            StavkeDodajVM model = new StavkeDodajVM
            {
                KategorijaId = kategorijaId,
                KursId = 0,//_db.Kategorija.Where(k=>k.Id==kat.Id).Count()+1,
                MaxBroj=0,
                Naziv="",
                Predavaci = _db.Predavac.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Ime
                }).ToList()
            };
            return PartialView("Dodaj", model);
        }

        public IActionResult Snimi(int kursId, int kategorijaId, string Naziv, int MaxBroj, int PredavacId)
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

            //int id = y.Kurs.Count() + 1;
            x.Id = kursId;
            x.KategorijaId = kategorijaId;
            x.Naziv = Naziv;
            x.MaxBrojPolaznika = MaxBroj;
            x.PredavacId = PredavacId;
            //x.MaterijaliId = 1;
 
            _db.SaveChanges();
            //return RedirectToAction("Detalji", "Kategorija","/Kategorija/Detalji/?id="+ kategorijaId);
            return Redirect("/Kategorija/Detalji?id=" + kategorijaId);

            //return Redirect("/StavkeAjax/Index?kategorijaId=" + kategorijaId);
        }
    }
}