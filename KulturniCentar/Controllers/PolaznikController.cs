using KulturniCentar.Data.Models;
using KulturniCentar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using KulturniCentar.Helper;

namespace KulturniCentar.Controllers
{
    public class PolaznikController : Controller
    {
        private readonly CoreDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //private readonly JWTSettings _jwtsettings;
        private readonly Authorize _authorize;



        public PolaznikController(CoreDbContext db, IWebHostEnvironment webHostEnvironment)//, IOptions<JWTSettings> jwtsettings)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            //_jwtsettings = jwtsettings.Value;
            _authorize = new Authorize(db);

        }
        //[Authorize(Role = "Admin")]
        public IActionResult Index()
        {
            //string stringFileName = UploadFile(vm);

            //var model = new PolaznikIndexVM
            //{
            //    rows = _db.Polaznik.Select(x => new PolaznikIndexVM.Row
            //    {
            //        Id = x.Id,
            //        Ime = x.Ime,
            //        Prezime = x.Prezime,
            //        Email = x.Email,
            //        KorisnickiRacunId = x.KorisnickiRacunId,
            //        Telefon = x.Telefon,
            //        korisnickoIme = x.KorisnickiRacun.KorisnickoIme,
            //        UspjehId = 1,
            //        Uspjeh = x.Uspjeh.Prosjek,
            //    }).ToList()
            //};

            //Authorize authorize = new Authorize(_db);
            if (Global.Token!= null)
            {
                var model = _db.Polaznik.ToList();
                return View("Index", model);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Dodaj()
        {
            if (_authorize.IsAuthorized())
            {
                var model = new PolaznikDodajUrediVM
                {
                    KorisnickiRacun = _db.KorisnickiRacun.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.KorisnickoIme }).ToList()
                };
                return View("Dodaj", model);
            }
            return BadRequest("Niste autorizovani!");
        }


      

        public IActionResult Uredi(int polaznikId)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin() )
            {
                Polaznik p = _db.Polaznik.Where(x => x.Id == polaznikId).FirstOrDefault();

                var model = new PolaznikDodajUrediVM
                {
                    PolaznikId = p.Id,
                    Ime = p.Ime,
                    Prezime = p.Prezime,
                    Email = p.Email,
                    Telefon = p.Telefon,
                    KorisnickiRacun = _db.KorisnickiRacun.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.KorisnickoIme }).ToList(),
                    Route = p.Slika
                    //UspjehId=p.UspjehId
                };
                return View("Uredi", model);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Obrisi(int polaznikId)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                Polaznik p = _db.Polaznik.Find(polaznikId);
                _db.Polaznik.Remove(p);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest("Niste autorizovani!");
        }
        public IActionResult SnimiSlika(PolaznikIndividualIndexVM vm)
        {
               var p = _db.Polaznik.Find(vm.Id);
               string stringFileName = UploadFile2(vm);
               p.Slika = stringFileName;
            _db.SaveChanges();
            return RedirectToAction("MojiPodaci");

        }
        public IActionResult Snimi(PolaznikDodajUrediVM vm)
        {
            if (_authorize.IsAuthorized() && _authorize.IsAdmin())
            {
                Polaznik p;
                if (vm.PolaznikId == 0)
                {
                    p = new Polaznik();
                    _db.Polaznik.Add(p);
                }
                else
                {
                    p = _db.Polaznik.Find(vm.PolaznikId);
                }

                string stringFileName = UploadFile(vm);

                p.Id = vm.PolaznikId;
                p.Ime = vm.Ime;
                p.Prezime = vm.Prezime;
                p.Email = vm.Email;
                p.Telefon = vm.Telefon;
                p.KorisnickiRacunId = vm.KorisnickiRacunId;
                p.UspjehId = 1;
                p.Slika = stringFileName;

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest("Niste autorizovani!");
        }

        private string UploadFile(PolaznikDodajUrediVM vm)
        {
            string fileName = null;
            if (vm.Slika != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + vm.Slika.FileName;
                string filePath = Path.Combine(uploadDir, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    vm.Slika.CopyTo(fileStream);
                }
            }
            return fileName;
        }
        private string UploadFile2(PolaznikIndividualIndexVM vm)
        {
            string fileName = null;
            if (vm.Slika != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + vm.Slika.FileName;
                string filePath = Path.Combine(uploadDir, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    vm.Slika.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        // here starts "Moji Podaci" section for individual view of user
        public IActionResult UcitajPrisustva(int polaznikId)
        {
            if (_authorize.IsAuthorized())
            {
                var p = _db.PolaznikCiklus.Include(x => x.Ciklus).Where(x => x.PolaznikId == polaznikId).FirstOrDefault();
                var model = new PrisustvoIndividualVM
                {
                    rows = _db.PolaznikCiklus.Include(x => x.Ciklus).Where(x => x.PolaznikId == p.PolaznikId).Select(x => new PrisustvoIndividualVM.Row
                    {
                        KursId = x.Ciklus.KursId,
                        Kurs = x.Ciklus.Kurs.Naziv,
                        Prisutan = IzracunajPrisustvo(polaznikId, p.CiklusId)
                    }).ToList()
                };
                return View("Prisustvo", model);
            }
            return BadRequest("Niste autorizovani!");
        }

        private float IzracunajPrisustvo(int polaznikId, int ciklusId)
        {
            float brojac = 0;
            var c = _db.PolaznikCiklus.Include(x => x.Ciklus.Susreti).ThenInclude(y => y.Prisustvo).Where(x => x.CiklusId == ciklusId && x.PolaznikId == polaznikId).Select(x => x.Ciklus).FirstOrDefault();
            foreach (var s in c.Susreti)
            {
                foreach (var p in s.Prisustvo)
                {
                    if (p.PolaznikId == polaznikId && p.Prisutan == true)
                        brojac++;
                }

            }
            float prosjek = 0;
            prosjek = c.Susreti.Count() / brojac;

            return prosjek;

        }

        public IActionResult MojiPodaci()
        {
            if(Global.Role!="Polaznik")
                return BadRequest("Niste autorizovani!");


            Polaznik p = _db.Polaznik.Include(x => x.Uspjeh).Include(x => x.KorisnickiRacun).Where(x => x.KorisnickiRacunId == Global.KorisnickiRacunId).FirstOrDefault();
            if (p != null)
            {
                var model = new PolaznikIndividualIndexVM
                {
                    Id = p.Id,
                    Ime = p.Ime,
                    Prezime = p.Prezime,
                    Email = p.Email,
                    KorisnickiRacunId = p.KorisnickiRacunId,
                    Telefon = p.Telefon,
                    korisnickoIme = p.KorisnickiRacun.KorisnickoIme,
                    //UspjehId = 2,
                    //Uspjeh = p.Uspjeh.Prosjek,
                    Route = p.Slika
                };
                return View("MojiPodaci", model);
            }
            return BadRequest("Niste autorizovani!");
        }

    }
}
