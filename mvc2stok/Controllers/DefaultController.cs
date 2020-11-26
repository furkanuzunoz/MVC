using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc2stok.Models.Entity;

namespace mvc2stok.Controllers
{
    public class DefaultController : Controller
    {
        mvcdbEntities db = new mvcdbEntities();
        // GET: Default
        public ActionResult Index()
        {
            var degerler = db.tblkategori.ToList();
            return View(degerler);
        }
        
        public ActionResult Yenikategoriekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yenikategoriekle(tblkategori p1 )
        {
            if (!ModelState.IsValid)
            {
                return View("Yenikategoriekle");

            }
            db.tblkategori.Add(p1);
            db.SaveChanges();
            return View();
        }
        
        public ActionResult Sil (int id)
        {
            var a = db.tblkategori.Find(id);
            db.tblkategori.Remove(a);
            db.SaveChanges();

            return RedirectToAction("index");
        }
        public ActionResult guncelle (int id)
        {
            var a = db.tblkategori.Find(id);

            return View("guncelle",a);

        }
        public ActionResult Guncelleee(tblkategori p1)
        {
            var a = db.tblkategori.Find(p1.kategoriid);
            a.kategoriad = p1.kategoriad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}