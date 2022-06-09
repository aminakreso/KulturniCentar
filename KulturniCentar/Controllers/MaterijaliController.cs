using KulturniCentar.Data.Models;
using KulturniCentar.Helper;
using KulturniCentar.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KulturniCentar.Controllers
{
    public class MaterijaliController : Controller
    {
        private readonly CoreDbContext _db;
        private readonly Authorize _authorize;

        public MaterijaliController(CoreDbContext db)
        {
            _db = db;
            _authorize = new Authorize(db);
        }
        public IActionResult Index(int susretId)
        {
            if (_authorize.IsAuthorized())
            {
                var s = _db.Susret.Find(susretId);
                var model = new MaterijaliIndexVM()
                {
                    SusretId = susretId,
                    Susret = s.Naziv,
                    Rows = _db.Materijali.Select(x => new MaterijaliIndexVM.Row
                    {
                        Id = x.Id,
                        Naziv = x.Naziv,
                        Kreirano=x.Kreirano,
                        Tip=x.Tip
                    }).ToList()
                };
                return View("Index", model);
            }
            return BadRequest("Niste autorizovani!");
        }
        [HttpPost]
        public IActionResult FileUpload(IFormFile files, int susretId)
        {
            if (_authorize.IsAuthorized() && ( _authorize.IsPredavac() || _authorize.IsAdmin()))
            {
                if (files != null)
                {
                    if (files.Length > 0)
                    {
                        var fileName = Path.GetFileName(files.FileName);
                        var fileExtension = Path.GetExtension(fileName);
                        var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                        var objfiles = new Materijali
                        {
                            Naziv = fileName,
                            Tip = fileExtension,
                            Kreirano = DateTime.Now,
                            SusretId = susretId,
                        };

                        using (var target = new MemoryStream())
                        {
                            files.CopyTo(target);
                            objfiles.DataFiles = target.ToArray();
                        }

                        _db.Materijali.Add(objfiles);
                        _db.SaveChanges();
                    }
                }
                return Redirect("Index?susretId=" + susretId);
            }
            return BadRequest("Niste autorizovani!");
        }

        public IActionResult Obrisi(int materijaliId)
        {
            if (_authorize.IsAuthorized() && (_authorize.IsAdmin() || _authorize.IsPredavac()))
            {
                var m = _db.Materijali.Find(materijaliId);
                var susretId = m.SusretId;
                _db.Materijali.Remove(m);
                _db.SaveChanges();
                return Redirect("Index?susretId=" + susretId);
            }
            return BadRequest("Niste autorizovani!");
        }
    }
}
