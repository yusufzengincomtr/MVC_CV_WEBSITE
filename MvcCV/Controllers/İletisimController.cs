using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class İletisimController : Controller
    {
        // GET: İletisim
        GenericRepository<TBLILETISIM> repo = new GenericRepository<TBLILETISIM>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
        public ActionResult İletisimSil(int id)
        {
            var iletisim = repo.Find(x => x.ID == id);
            repo.TDelete(iletisim);
            return RedirectToAction("Index");
        }

      
    }
}