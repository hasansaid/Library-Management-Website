using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane2.Models;

namespace MvcKutuphane2.Controllers
{
    public class OduncController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Odunc
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {

            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET p)
        {
            db.TBLHAREKET.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Odunciade(int id)
        {
            var odn = db.TBLHAREKET.Find(id);
            return View("Odunciade", odn);
        }
    }
}