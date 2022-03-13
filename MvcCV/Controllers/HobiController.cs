using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;
namespace MvcCV.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TBLHOBİLERİM> repo = new GenericRepository<TBLHOBİLERİM>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
        public ActionResult Index(TBLHOBİLERİM p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            t.Aciklama3 = p.Aciklama3;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}