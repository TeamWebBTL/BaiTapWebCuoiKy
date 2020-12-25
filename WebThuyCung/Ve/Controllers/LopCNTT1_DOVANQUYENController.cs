using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using Ve.Models;

namespace Ve.Controllers
{
    public class LopCNTT1_DOVANQUYENController : Controller
    {
          // GET: LopCNTT1_DOVANQUYEN
          MyDB myDB = new MyDB();
        public ActionResult Index()
        {
            var lst = myDB.KHACHHANGs.ToList();
            return View(lst);
        }
          public ActionResult DangKy()
          {               
               return View();
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
                         myDB.KHACHHANGs.Add(kh);
                         myDB.SaveChanges();
                    }
                    else
                    {
                         ViewBag.ThongBao = "Thêm thất bại";
                    }

                    return View();
               }

               ViewBag.ThongBao = "Sai mã Captcha";
               return RedirectToAction("Index", "LopCNTT1_DOVANQUYEN");
          }
          public ActionResult Xoa(int? maKH)
          {
               KHACHHANG kh = myDB.KHACHHANGs.Where(x => x.ID == maKH).FirstOrDefault();
               myDB.KHACHHANGs.Remove(kh);
               myDB.SaveChanges();
               return RedirectToAction("Index","LopCNTT1_DOVANQUYEN");
          }
     }
}