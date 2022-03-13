using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class YetenekController : Controller
    {
  
        GenericRepository<TBLYETENEKLERIM> repo = new GenericRepository<TBLYETENEKLERIM>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        public ActionResult YetenekSil(int id)
        {
            var yeteneksil= repo.Find(x => x.ID == id);
            repo.TDelete(yeteneksil);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TBLYETENEKLERIM p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekDuzenle(TBLYETENEKLERIM t)
        {
            var y = repo.Find(x => x.ID == t.ID);
            y.Yetenek = t.Yetenek;
            y.Oran = t.Oran;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}