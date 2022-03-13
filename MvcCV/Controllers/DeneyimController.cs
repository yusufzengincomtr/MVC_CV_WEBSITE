using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;

namespace MvcCV.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TBLDENEYİMLERİM p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            TBLDENEYİMLERİM t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TBLDENEYİMLERİM t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TBLDENEYİMLERİM p)
        {
            TBLDENEYİMLERİM t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.Altbaslik = p.Altbaslik;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}