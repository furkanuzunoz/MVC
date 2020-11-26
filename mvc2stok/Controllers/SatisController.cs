using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using mvc2stok.Models.Entity;

namespace mvc2stok.Controllers
{
    
    public class SatisController : Controller
    {
        mvcdbEntities db = new mvcdbEntities();

        // GET: Satis
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Satisyap()
        {

            return View("index");
        }
        [HttpPost]
        public ActionResult Satisyap(tblsatıis p1)
        {
            db.tblsatıis.Add(p1);
            db.SaveChanges();

            return View("index");
        }
        


        
    }
}