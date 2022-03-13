using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private const string ViewName = "İletisim";

        // GET: Default
        DbCVEntities1 db = new DbCVEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBLHAKKIMDA.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TBLSOSYALMEDYA.Where(x => x.durum == true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TBLDENEYİMLERİM.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TBLEGİTİMLERİM.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TBLYETENEKLERIM.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TBLHOBİLERİM.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalarım()
        {
            var hobiler = db.TBLSERTİFİKALARIM.ToList();
            return PartialView(hobiler);
        }
        [HttpGet]
        public PartialViewResult İletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult İletisim(TBLILETISIM t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLILETISIM.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}