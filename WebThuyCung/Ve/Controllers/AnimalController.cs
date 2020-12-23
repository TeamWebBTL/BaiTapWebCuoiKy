using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Ve.Models;

namespace Ve.Controllers
{
    public class AnimalController : Controller
    {
        MyDB db = new MyDB();
        // GET: Animal

        public SINHVAT GetSINHVAT()
        {
            return db.SINHVATs.Where<SINHVAT>(c => c.ID == 1).FirstOrDefault();
        }
        public ActionResult Index(string type,string color, string location)
        {
            ViewBag.listAnimal = (from sv in db.SINHVATs select sv).ToList();

            /*  if (!String.IsNullOrEmpty(type) || !String.IsNullOrEmpty(color) || !String.IsNullOrEmpty(location))
              {
                  ViewBag.listAnimal = db.SINHVATs.Where(c => c.Loai == type)(c => c.MauSac == color).Where(c => c.ViTri == location).ToList();
              }*/


            if (!string.IsNullOrWhiteSpace(Request.QueryString["type"]))
            {
                ViewBag.listAnimal = db.SINHVATs.Where(c => c.Loai == type).ToList();
            }

           else if (!string.IsNullOrWhiteSpace(Request.QueryString["color"]))
            {
                ViewBag.listAnimal = db.SINHVATs.Where(c => c.MauSac == color).ToList();
            }
           else if (!string.IsNullOrWhiteSpace(Request.QueryString["location"]))
            {
                ViewBag.listAnimal = db.SINHVATs.Where(c => c.ViTri == location).ToList();
            }
            else
            {
                return View();
            }
            return View();
       
        }
        public ActionResult Details(int id)
        {
            var sv = db.SINHVATs.Where(c => c.ID == id).FirstOrDefault();
            return View(sv);
        }
        public ActionResult filtersinhvat(string type)
        {
            var sks = db.SINHVATs.Where(c => c.Loai == type).ToList();
            return View(sks);


        }
    }
}