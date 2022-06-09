using KulturniCentar.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.Controllers
{
    public class KorisnickiRacunController : Controller
    {
        private readonly CoreDbContext _db;

        public KorisnickiRacunController(CoreDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<KorisnickiRacun> k = _db.KorisnickiRacun.ToList();

            ViewData["podaciKljuc"] = k;
            return View();
        }
    }
}
