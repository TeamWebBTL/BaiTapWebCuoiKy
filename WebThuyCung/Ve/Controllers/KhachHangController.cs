using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ve.Models;

namespace Ve.Controllers
{
    public class KhachHangController : Controller
    {
          MyDB db = new MyDB();
        // GET: KhachHang
        public ActionResult Index()
        {
            var ND = (KHACHHANG)Session["Account"];
            KHACHHANG Kh = db.KHACHHANGs.Where(x => x.ID == ND.ID).FirstOrDefault();
            return View(ND);
        }
          public ActionResult ProfileKH()
          {
               var ND = (KHACHHANG)Session["Account"];
               KHACHHANG Kh = db.KHACHHANGs.Where(x => x.ID == ND.ID).FirstOrDefault();
               return View(Kh);
          }
          [HttpPost]
          public ActionResult Update(string txtHoTen,string txtDiaChi)
          {
               var ND = (KHACHHANG)Session["Account"];
               KHACHHANG Kh = db.KHACHHANGs.Where(x => x.ID == ND.ID).FirstOrDefault();
               if(Kh != null)
               {
                    
                    Kh.DiaChi = txtDiaChi;
                    Kh.Ten = txtHoTen;                   
                    db.SaveChanges();
               }
               return RedirectToAction("Index","KhachHang");
          }
     }
}