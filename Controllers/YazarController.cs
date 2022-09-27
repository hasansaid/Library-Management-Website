using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane2.Models;

namespace MvcKutuphane2.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var deger = db.TBLYAZAR.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TBLYAZAR p)
        {
            db.TBLYAZAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarSil(int id)
        {
            var yazar = db.TBLYAZAR.Find(id);
            db.TBLYAZAR.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int id)
        {
            var yzr = db.TBLYAZAR.Find(id);
            return View("YazarGetir");
        }

        public ActionResult YazarGuncelle(TBLYAZAR p)
        {
            var yazr = db.TBLYAZAR.Find(p.ID);
            yazr.AD = p.AD;
            yazr.SOYAD = p.SOYAD;
            yazr.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}