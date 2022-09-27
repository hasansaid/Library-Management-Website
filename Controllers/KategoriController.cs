using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane2.Models;
namespace MvcKutuphane2.Controllers
{
    public class KategoriController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        
        
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORI.ToList();
            return View(degerler);
        }
        [HttpGet]
        
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult KategoriEkle(TBLKATEGORI p)
        {
            db.TBLKATEGORI.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGuncelle(TBLKATEGORI p)
        {
            var ktg = db.TBLKATEGORI.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}