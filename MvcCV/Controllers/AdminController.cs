using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TBLADMİN> repo = new GenericRepository<TBLADMİN>();
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(TBLADMİN p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            TBLADMİN t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            TBLADMİN t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminDuzenle(TBLADMİN p)
        {
            TBLADMİN t = repo.Find(x => x.ID == p.ID);
            t.KullaniciAdi = p.KullaniciAdi;
            t.sifre = p.sifre;
 
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}