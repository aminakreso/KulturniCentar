using KulturniCentar.Data.Models;
using KulturniCentar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.Controllers
{
    public class PrisustvoController : Controller
    {
        private readonly CoreDbContext _db;
        public IActionResult Index(int susretId)
        {
            var model = new PrisustvoVM
            {
                SusretId = susretId,
                Susret = susretId.ToString(),
                rows = _db.Prisustvo.Select(x => new PrisustvoVM.Row
                {
                    Id = x.Id,
                    PolaznikId = x.PolaznikId,
                    Prisutan = x.Prisutan,

                }).ToList()
            };
            return View("Index", model);
        }

        //public IActionResult JePrisutan(int polaznikId)
        //{
        //    var prisutan = _db.Prisustvo.Where(x => x.Id == polaznikId).FirstOrDefault();
        //    prisutan.Prisutan = true;
        //    _db.Prisustvo.Update(prisutan);
        //    _db.SaveChanges();

        //    return RedirectToAction("Index");
        //}
        //public IActionResult NijePrisutan(int polaznikId)
        //{
        //    var prisutan = _db.Prisustvo.Where(x => x.Id == polaznikId).FirstOrDefault();
        //    prisutan.Prisutan = false;
        //    _db.Prisustvo.Update(prisutan);
        //    _db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //public IActionResult Snimi(int polaznikId, int prisustvoId, bool prisutan)
        //{
        //    Prisustvo p;
        //    if (prisustvoId == 0)
        //    {
        //        p = new Prisustvo();
        //        _db.Prisustvo.Add(p);
        //    }
        //    else
        //    {
        //        p = _db.Prisustvo.Find(prisustvoId);
        //    }
        //    p.PolaznikId= polaznikId;
        //    p.Prisutan = prisutan;
        //    _db.SaveChanges();
        //    return Redirect("Index?Prisustvo=" + prisustvoId);
        //}
    }
}
