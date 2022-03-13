using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using System.Web.Security;

namespace MvcCV.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBLADMİN p)
        {
            DbCVEntities1 db = new DbCVEntities1();
            var bilgi = db.TBLADMİN.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.sifre == p.sifre);

            if (bilgi!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgi.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Hakkimda");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}