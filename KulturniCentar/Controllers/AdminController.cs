using KulturniCentar.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.Controllers
{
    public class AdminController : Controller
    {
        private readonly CoreDbContext _db;
      
        public AdminController(CoreDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Admin> a = _db.Admin.Include(k=>k.KorisnickiRacun).ToList();

            ViewData["nekiKey"] = a;
            return View();
        }
    }
}
