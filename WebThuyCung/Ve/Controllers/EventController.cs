using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ve.Models;

namespace Ve.Controllers
{
    public class EventController : Controller
    {
        MyDB db = new MyDB();
        public SUKIEN GetSUKIEN()
        {
            return db.SUKIENs.Where<SUKIEN>(c => c.ID == 1).FirstOrDefault();
        }
        // GET: Event
        public ActionResult Index(string type)
        {

            ViewBag.type = type;
            ViewBag.listEvent = (from sk in db.SUKIENs select sk).ToList();
            if (!String.IsNullOrEmpty(type))
            {
                ViewBag.listEvent = db.SUKIENs.Where(c => c.LoaiSuKien == type).ToList();
            }
            var SK = db.SUKIENs.Where(c => c.LoaiSuKien == type).FirstOrDefault();
            return View();
        }
        public ActionResult Details(int id)
        {
            var sk = db.SUKIENs.Where(c => c.ID == id).FirstOrDefault();
            return View(sk);
        }
       /* public ActionResult filtersukien(string type)
        {
            var sks = db.SUKIENs.Where(c => c.LoaiSuKien == type).ToList();
            return View(sks);
        }*/
    }
}