using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane2.Models;

namespace MvcKutuphane2.Controllers
{
    public class PersonelController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = db.TBLPERSONEL.ToList();
            return View(degerler);
        }
        [HttpGet]

        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]

        public ActionResult PersonelEkle(TBLPERSONEL p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TBLPERSONEL.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var person = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var prs = db.TBLPERSONEL.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(TBLPERSONEL p)
        {
            var prss = db.TBLPERSONEL.Find(p.ID);
            prss.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}