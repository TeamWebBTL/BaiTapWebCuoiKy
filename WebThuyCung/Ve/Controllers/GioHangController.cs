using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ve.Models;

namespace Ve.Controllers
{
     public class GioHangController : Controller
     {
          MyDB db = new MyDB();
          // GET: GioHang
          public ActionResult GioHangPartial()
          {
               return View();
          }
          public List<ItemGioHang> LayGioHang()
          {
               List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
               if (lstGioHang == null)
               {
                    //Nếu session bằng  null thì khởi tạo gio hàng
                    lstGioHang = new List<ItemGioHang>();
                    // Gán lại giỏ hàng cho session
                    Session["GioHang"] = lstGioHang;
               }
               // nếu giỏ hàng khác null ( đã có sản phẩm trong giỏ ) thì trả về  list
               return lstGioHang;
          }

          
          public ActionResult XemGioHang()
          {

               if (Session["Account"] == null)
               {
                    Response.StatusCode = 404;
                    return null;
               }
               else
               {
                    var ND = (KHACHHANG)Session["Account"];
                    var GioHang = db.GIOHANGs.Where(KH => KH.ID_KhachHang == ND.ID).ToList();
                    if (GioHang.Count() == 0)
                    {                         
                         return PartialView("GioTrong");
                    }
                    else
                    {
                         return PartialView("XemGioHang",GioHang);
                    }
               }
          }         
          [HttpPost]
          public ActionResult ThemSP2(int mave,FormCollection f)
          {
               var Ve = db.VEs.SingleOrDefault(m => m.ID == mave);
               if (Ve == null)
               {
                    //Trả về trang đường dẫn không hợp lệ
                    Response.StatusCode = 404;
                    return null;
               }               
               else
               {
                    KHACHHANG ND = (KHACHHANG)Session["Account"];
                    var MaND = ND.ID;
                    var ItemOfCart = db.GIOHANGs.SingleOrDefault(m => m.ID_Ve == mave && m.ID_KhachHang == MaND);
                    string Soluong = f["txtSoLuong"].ToString();
                    if (ItemOfCart == null)
                    {
                         GIOHANG gh = new GIOHANG();
                         gh.ID_KhachHang = MaND;
                         gh.ID_Ve = mave;
                         gh.SoLuong = Int32.Parse(Soluong);
                         db.GIOHANGs.Add(gh);
                         db.SaveChanges();
                    }
                    else
                    {

                         ItemOfCart.SoLuong = ItemOfCart.SoLuong + Int32.Parse(Soluong);
                         db.SaveChanges();
                    }

                    return View("ChiTietVe", "Ticket");
               }
          }
          [ChildActionOnly]
          public ActionResult ChiTietVe(int mave, int soluong)
          {
               ViewBag.SoLuong = soluong;
               var CTVe = db.VEs.Where(v => v.ID == mave).ToList();
               return PartialView(CTVe);
          }
          public ActionResult XoaSP(int mave)
          {
               var Ve = db.VEs.SingleOrDefault(m => m.ID == mave);
               if (Ve == null)
               {
                    //Trả về trang đường dẫn không hợp lệ
                    Response.StatusCode = 404;
                    return null;
               }
               else
               {
                    KHACHHANG ND = (KHACHHANG)Session["Account"];
                    var MaND = ND.ID;
                    var ItemOfCart = db.GIOHANGs.SingleOrDefault(m => m.ID_Ve == mave && m.ID_KhachHang == MaND);
                    if (ItemOfCart != null)
                    {
                         db.GIOHANGs.Remove(ItemOfCart);
                         db.SaveChanges();
                    }
                    else
                    {
                         return PartialView("GioTrong");
                    }
                    var GioHang = db.GIOHANGs.Where(KH => KH.ID_KhachHang == ND.ID).ToList();
                    if (GioHang.Count() == 0)
                    {
                         return PartialView("GioTrong");
                    }
                    else
                    {
                         return PartialView("XemGioHang",GioHang);
                    }
               }

          }
     }
}
