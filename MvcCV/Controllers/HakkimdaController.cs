using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;
namespace MvcCV.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda

        GenericRepository<TBLHAKKIMDA> repo = new GenericRepository<TBLHAKKIMDA>();
        [HttpGet]

        public ActionResult Index()
        {
            var hakkımda = repo.List();
            return View(hakkımda);
        }
        [HttpPost]
        public ActionResult Index(TBLHAKKIMDA p)
        {

             if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);

                string uzanti = Path.GetExtension(Request.Files[0].FileName);

                string yol = "~/image/" + dosyaadi + uzanti;

                Request.Files[0].SaveAs(Server.MapPath(yol));

                p.Resim = "/image/" + dosyaadi + uzanti;
            }

            var t = repo.Find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Mail = p.Mail;
            t.Telefon = p.Telefon;
            t.Aciklama = p.Aciklama;
            t.Resim = p.Resim;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}

