using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc2stok.Models.Entity;
namespace mvc2stok.Controllers
{
    public class MusteriController : Controller
    {
        mvcdbEntities db = new mvcdbEntities();
        // GET: Musteri
        public ActionResult Index(string p)
        {
            var degerler = from d in db.tblmusteri select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.musteriad.Contains(p));
            }

            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult Musteriekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Musteriekle(tblmusteri p2)
        {
            if (!ModelState.IsValid)
            {
                return View("Musteriekle");
            }
            db.tblmusteri.Add(p2);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil (int id)
        {
            var a = db.tblmusteri.Find(id);
            db.tblmusteri.Remove(a);
            db.SaveChanges();

            return RedirectToAction("index");
        }
        public ActionResult musterigetir(int id)
        {
            var a = db.tblmusteri.Find(id);
            return View("musterigetir", a);
        }
        public ActionResult guncelle(tblmusteri p1)
        {
            var a = db.tblmusteri.Find(p1.musteriid);
            a.musteriad = p1.musteriad;
            a.musterisoyad = p1.musterisoyad;
            db.SaveChanges();
            return RedirectToAction("index");

        }
    }
}