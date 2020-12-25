using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using Ve.Models;

namespace Ve.Controllers
{
    public class ThanhToanController : Controller
    {
          MyDB db = new MyDB();
        // GET: ThanhToan
        
        public ActionResult Index(int tongtien)
        {
               
               var ND = (KHACHHANG)Session["Account"];
               ViewBag.TongTien = tongtien;
               List<GIOHANG> lstGH = db.GIOHANGs.Where(x => x.ID_KhachHang == ND.ID).ToList();              
               ViewBag.lstGH= lstGH;
               if(tongtien >= 1000000)
               {
                    ViewBag.FPhiShip = -39000;
               }
               else
               {
                    ViewBag.FPhiShip = 0;
               }
               return View(ND);
               
        }
          [HttpPost]
          //public ActionResult Index1( string txtName)
          //{
          //     KHACHHANG Kh = new KHACHHANG();
          //     Kh.Ten = txtName;
          //     return RedirectToAction("Index", "ThanhToan",1500000);
               
          //}
          public ActionResult Shipping()
          {
              return View();
          }
         public List<GIOHANG> LayGioHang()
         {
            var ND = (KHACHHANG)Session["Account"];
            var lstGioHang = db.GIOHANGs.Where(x=>x.ID_KhachHang == ND.ID).ToList();
            if (lstGioHang == null)
            {
                    //Nếu session bằng  null thì khởi tạo gio hàng
                    lstGioHang = new List<GIOHANG>();
                    // Gán lại giỏ hàng cho session
                    Session["GioHang"] = lstGioHang;
            }
               // nếu giỏ hàng khác null ( đã có sản phẩm trong giỏ ) thì trả về  list
               return lstGioHang;
        }  
          public ActionResult XacNhan(string tongtien,string Name,string Phone,string adress)
          {
               KHACHHANG ND = (KHACHHANG)Session["Account"];
               if (ND == null)
               {
                    //Trả về trang đường dẫn không hợp lệ
                    Response.StatusCode = 404;
                    return null;
               }
               else
               {
                    string Tong = tongtien;
                    string Ten = Name;
                    string DC = adress;
                    string SDT = Phone;
                    DONDATHANG ddh = new DONDATHANG();
                    ddh.NgayDat = DateTime.Now;
                    ddh.HoTen = Ten;
                    ddh.DiaChi = DC;
                    ddh.SĐT = SDT;
                    ddh.TongTien = Tong;
                    ddh.ID_KhachHang = ND.ID;
                    ddh.TinhTrang = "Đang Xử Lý";
                    db.DONDATHANGs.Add(ddh);
                    db.SaveChanges();
                    List<GIOHANG> lstGioHang = LayGioHang();
                    foreach (var item in lstGioHang)
                    {
                         CHITIETDONHANG ctdh = new CHITIETDONHANG();
                         ctdh.ID_DDH = ddh.ID;
                         ctdh.ID_Ve = item.ID_Ve;
                         ctdh.SoLuong = item.SoLuong;
                         ctdh.DonGia = item.VE.DonGia;
                         db.CHITIETDONHANGs.Add(ctdh);
                         db.SaveChanges();
                         db.GIOHANGs.Remove(item);
                         db.SaveChanges();
                    }
               }
               GuiEmail("Xác nhận đơn hàng", ND.Email, "hoangtrecon123@gmail.com", "01688865058a", "Đơn hàng của bạn đã được đặt thành công");
               return RedirectToAction("XemDonHang","ThanhToan");
               
          }
          public void GuiEmail(string Title, string ToEmail, string FromEmail, string PassWord, string Content)
          {
               // goi email
               MailMessage mail = new MailMessage();
               mail.To.Add(ToEmail); // Địa chỉ nhận
               mail.From = new MailAddress(ToEmail); // Địa chửi gửi
               mail.Subject = Title;  // tiêu đề gửi
               mail.Body = Content;                 // Nội dung
               mail.IsBodyHtml = true;
               SmtpClient smtp = new SmtpClient();
               smtp.Host = "smtp.gmail.com"; // host gửi của Gmail
               smtp.Port = 587;               //port của Gmail
               smtp.UseDefaultCredentials = false;
               smtp.Credentials = new NetworkCredential(FromEmail, PassWord);//Tài khoản password người gửi
               smtp.EnableSsl = true;   //kích hoạt giao tiếp an toàn SSL
               smtp.Send(mail);   //Gửi mail đi
          }
          public ActionResult XemDonHang()
          {
               var ND = (KHACHHANG)Session["Account"];
               // Ds đơn hàng chưa duyệt
               var lst = db.DONDATHANGs.Where(x=>x.ID_KhachHang == ND.ID).OrderBy(n => n.NgayDat);
               return View(lst);
          }
          
          public ActionResult XemDonHang1(string TT)
          {
               var ND = (KHACHHANG)Session["Account"];
               // Ds đơn hàng chưa duyệt
               var lst = db.DONDATHANGs.Where(x => x.ID_KhachHang == ND.ID && x.TinhTrang == TT ).OrderBy(n => n.NgayDat);
               return View(lst);
          }
          public ActionResult ChiTietDH(int? MaHD)
          {
               var lst = db.CHITIETDONHANGs.Where(x => x.ID_DDH == MaHD).ToList();
               return View(lst);
          }
     }
}