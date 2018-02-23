using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_State.Models;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace Real_State.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contacts()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Contact (EmailForm model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
        //        var message = new MailMessage();
        //        message.To.Add(new MailAddress("recipient@gmail.com"));  // replace with valid value 
        //        message.From = new MailAddress("sender@outlook.com");  // replace with valid value
        //        message.Subject = "Your email subject";
        //        message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
        //        message.IsBodyHtml = true;

        //        using (var smtp = new SmtpClient())
        //        {
        //            var credential = new NetworkCredential
        //            {
        //                UserName = "user@outlook.com",  // replace with valid value
        //                Password = "password"  // replace with valid value
        //            };
        //            smtp.Credentials = credential;
        //            smtp.Host = "smtp-mail.outlook.com";
        //            smtp.Port = 587;
        //            smtp.EnableSsl = true;
        //           // await smtp.SendMailAsync(message);
        //            return RedirectToAction("Sent");
        //        }
        //    }
        //    return View(model);
        //}

        [HttpPost]
        public ActionResult Contacts(Real_State.Models.EmailForm model)
        {
            MailMessage mm = new MailMessage(model.From, "sxg85140@ucmo.edu");

            mm.Subject = model.Subject;
            //mm.Body = model.Body;
            

            mm.Body = model.Body + " Phone No. :"+model.PhoneNo.ToString();

            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("sxg85140@ucmo.edu", "Ucmo.9229");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail sent successfully";
            return View();
        }
        public ActionResult Sent()
        {
            return View();
        }
    }
}