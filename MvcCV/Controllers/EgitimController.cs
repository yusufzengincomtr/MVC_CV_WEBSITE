using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        GenericRepository<TBLEGİTİMLERİM> repo = new GenericRepository<TBLEGİTİMLERİM>();
        // GET: Egitim
     
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TBLEGİTİMLERİM p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitims = repo.Find(x => x.ID == id);
            repo.TDelete(egitims);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitims = repo.Find(x => x.ID == id);
            return View(egitims);
        }
        [HttpPost]
        public ActionResult EgitimDuzenle(TBLEGİTİMLERİM t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDuzenle");
            }
            var egitims = repo.Find(x => x.ID == t.ID);
            egitims.Baslik = t.Baslik;
            egitims.Altbaslik1 = t.Altbaslik1;
            egitims.Altbaslik2 = t.Altbaslik2;
            egitims.Tarih = t.Tarih;
            egitims.GNO = t.GNO;
            repo.TUpdate(egitims);
           return RedirectToAction("Index");
        }
    }
}