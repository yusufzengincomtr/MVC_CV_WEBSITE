using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TBLSOSYALMEDYA> repo = new GenericRepository<TBLSOSYALMEDYA>();
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TBLSOSYALMEDYA p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SayfaGetir(TBLSOSYALMEDYA p)
        {
            var hesap = repo.Find(x => x.ID == p.ID);
            hesap.Ad = p.Ad;
            hesap.durum = true;
            hesap.Link = p.Link;
            hesap.ikon = p.ikon;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}