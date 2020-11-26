using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc2stok.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace mvc2stok.Controllers
{
    public class UrunlerController : Controller
    {
        mvcdbEntities db = new mvcdbEntities();
        // GET: Urunler
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.tblurunler.ToList();
            var degerler = db.tblurunler.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Urunekle()
        {
            List<SelectListItem> degerler = (from i in db.tblkategori.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriad,
                                                 Value = i.kategoriid.ToString()
                                             }

                                             ).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult Urunekle(tblurunler p3)
        {
            db.tblurunler.Add(p3);
            db.SaveChanges();
            return View();

        }
        public ActionResult Sil(int id)
        {
            var a = db.tblurunler.Find(id);
            db.tblurunler.Remove(a);
            db.SaveChanges();

            return RedirectToAction("index");
        }
        public ActionResult Guncelle(int id)
        {
            var a = db.tblurunler.Find(id);
            return View("Guncelle", a);
        }
        public ActionResult Guncellee(tblurunler p1)
        {
            var ktgr = db.tblurunler.Find(p1.Urunid);
            ktgr.urunad = p1.urunad;
            ktgr.Urunmarka = p1.Urunmarka;
            ktgr.urunkategori = p1.urunkategori;
            ktgr.urunfiyat = p1.urunfiyat;
            ktgr.stok = p1.stok;
            db.SaveChanges();

            return RedirectToAction("index");

        }
    }
}