using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Repositories;
using MvcCV.Models.Entity;

namespace MvcCV.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TBLSERTİFİKALARIM> repo = new GenericRepository<TBLSERTİFİKALARIM>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x=>x.ID==id);
            ViewBag.d = id;
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TBLSERTİFİKALARIM t)
        {
            var sertifika = repo.Find(x => x.ID == t.ID);
            sertifika.Aciklama = t.Aciklama;
            sertifika.Tarih = t.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSertifika(TBLSERTİFİKALARIM t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
           
            var sertifika = repo.Find(x => x.ID == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}