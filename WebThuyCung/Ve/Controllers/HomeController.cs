using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;
using Ve.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace Ve.Controllers
{
    public class HomeController : Controller
    {
          MyDB db = new MyDB();
        // GET: Home
        public ActionResult DangKy()
        {

            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult Index()
        {
               var lstEv = db.SUKIENs.Take(2).ToList();
               return View(lstEv);
        }
          [HttpPost]
        public ActionResult DangKy(KHACHHANG kh)
        {
               
               //Kiểm tra Captcha hợp lệ
               if (this.IsCaptchaValid("Captcha is not valid"))
               {
                    if (ModelState.IsValid)
                    {
                         ViewBag.ThongBao = "Thêm thành công";
                         db.KHACHHANGs.Add(kh);
                         db.SaveChanges();
                    }
                    else
                    {
                         ViewBag.ThongBao = "Thêm thất bại";
                    }

                    return View();
               }

               ViewBag.ThongBao = "Sai mã Captcha";
               return View();
        }        
          //Xây dựng Action đăng nhập
          [HttpPost]
          public ActionResult Login(string txtTaiKhoan,string txtMatKhau)
          {
               string taikhoan = txtTaiKhoan;
               string matkhau = txtMatKhau;

               KHACHHANG tv = db.KHACHHANGs.SingleOrDefault(n => n.TaiKhoan == taikhoan && n.MatKhau == matkhau);
               if (tv != null)
               {                   
                    Session["Account"] = tv;
                    return RedirectToAction("Index", "Ticket");                                      
               }
               ViewBag.ThongBao = "Tài khoản hoặc mật khẩu không đúng!";
               return View();

          }        
          public ActionResult Dangxuat()
          {
               //Gán về null
               Session["Account"] = null;
               FormsAuthentication.SignOut();
               return RedirectToAction("Index","Ticket");
          }

     }
}
