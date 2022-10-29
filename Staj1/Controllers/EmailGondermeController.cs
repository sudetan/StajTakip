
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace emailgonderme.Controllers
{
    public class EmailgondermeController : Controller
    {
        // GET: Emailgonderme
        public ActionResult Index()
        {
            return View();
}
[HttpPost]
        public ActionResult Index(Staj1.Models.Kullanici model)
        {
            MailMessage sifremail = new MailMessage();
            sifremail.To.Add(model.Mail); // kime , kullanıcı maili çekilecek
            sifremail.From = new MailAddress("koustsmail@gmail.com"); // kimden, değişmeyecek
            sifremail.Subject = "KOU Staj Takip Sistemi Şifre";
            sifremail.Body = "Sayın " + model.Adi + "<br>" + model.Soyadi +  "<br> <br>" + "Şifreniz: " + model.Parola + "<br> <br>" + "Kullanıcı Adınız:" + model.Numara;
            sifremail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("koustsmail@gmail.com", "vqrsjwkmzahicyum");

            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;


            try
            {
                smtp.Send(sifremail);
                TempData["Message"] = "Şifre kullanıcıya iletilmiştir.";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Mesaj gönderilemedi. Hata nedeni: " + ex.Message;
            }

            return View();

        }
    }
}