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
               if (type == "ca") { ViewBag.Type = "Cá"; }
               else if (type == "luong_cu") { ViewBag.Type = "Lưỡng Cư"; }
               else if (type == "chim") { ViewBag.Type = "Chim"; }
               else if (type == "khong_xuong_song") { ViewBag.Type = "Không Xương Sống"; }
               else if (type == "co_vu") { ViewBag.Type = "Có Vú"; }
               else if (type == "bo_sat") { ViewBag.Type = "Bò Sát"; }
               else if (type == "ca_map") { ViewBag.Type = "Cá Mập"; }
               else if (type == "ca_duoi") { ViewBag.Type = "Cá Đuối"; }

               if(color == "trang") { ViewBag.Color = "Trắng"; }
               else if (color == "do") { ViewBag.Color = "Đỏ"; }
               else if (color == "cam") { ViewBag.Color = "Cam"; }
               else if (color == "vang") { ViewBag.Color = "Vàng"; }
               else if (color == "xanh_luc") { ViewBag.Color = "Xanh Lục"; }
               else if (color == "lam") { ViewBag.Color = "Lam"; }
               else if (color == "tim") { ViewBag.Color = "Tím"; }
               else if (color == "hong") { ViewBag.Color = "Hồng"; }
               else if (color == "nau") { ViewBag.Color = "Nâu"; }
               else if (color == "den") { ViewBag.Color = "Đen"; }
               else if (color == "xam") { ViewBag.Color = "Xám"; }

               if (location == "chau_phi") { ViewBag.Location = "Châu Phi"; }
               else if (location == "chau_a") { ViewBag.Location = "Châu Á"; }
               else if (location == "chau_uc") { ViewBag.Location = "Châu Úc"; }
               else if (location == "chau_au") { ViewBag.Location = "Châu Âu"; }
               else if (location == "bac_my") { ViewBag.Location = "Bắc Mỹ"; }
               else if (location == "nam_my") { ViewBag.Location = "Nam Mỹ"; }
               else if (location == "bac_bang_duong") { ViewBag.Location = "Bắc Băng Dương"; }
               else if (location == "dai_tay_duong") { ViewBag.Location = "Đại Tây Dương"; }
               else if (location == "an_do_duong") { ViewBag.Location = "Ấn Độ Dương"; }
               else if (location == "thai_binh_duong") { ViewBag.Location = "Thái Bính Dương"; }
               else if (location == "nam_dai_duong") { ViewBag.Location = "Nam Đại Dương"; }

               if (!string.IsNullOrWhiteSpace(Request.QueryString["location"]) || !string.IsNullOrWhiteSpace(Request.QueryString["location"]) || !string.IsNullOrWhiteSpace(Request.QueryString["location"]))
              {
                   ViewBag.listAnimal = db.SINHVATs.Where(c => c.Loai == type || c.MauSac == color || c.ViTri == location).ToList();
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