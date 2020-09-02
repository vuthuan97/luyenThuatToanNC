using ASPSnippets.GoogleAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace solution.chucnangWeb.Controllers
{
    public class HomeController : Controller
    {
        public string clientID = ConfigurationManager.AppSettings["ClientID"];
        public string SecretID = ConfigurationManager.AppSettings["SecretID"];
        public string RedirectUrl = ConfigurationManager.AppSettings["RedirectUrl"];
        public string url = "https://accounts.google.com/o/oauth2/token";
       
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult guimail()
        {
            string tieude = "gui mail tesst";
            string noidung = "<h4>GỬi mail thử nghiệm</4><p>Gửi mail thử nghiệm</p>";
            string mailnhan = "over191997@gmail.com";
            bool check1 = sendMail(tieude, mailnhan, noidung);
            bool check = SendMail(mailnhan,tieude,noidung);
            return Json(check, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login()
        {
            GoogleConnect.ClientId = clientID;
            GoogleConnect.ClientSecret = SecretID;
            GoogleConnect.RedirectUri = RedirectUrl;
            GoogleConnect.Authorize("profile", "email");
            return View();
        }

        public async Task<ActionResult> Contact(string code , string state,string sesion_state)
        {
                
                string json = GoogleConnect.Fetch("me", code);
                userprofile profile = new JavaScriptSerializer().Deserialize<userprofile>(json);


            return View(profile);
        }

       

        public bool SendMail(string mailnhan,string tieude,string noidung)
        {
            bool result = false;
            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(new MailAddress(mailnhan));
                msg.From = new MailAddress(ConfigurationManager.AppSettings["email"], "You");
                msg.Subject = tieude;
                msg.Body = noidung;
                msg.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["email"], ConfigurationManager.AppSettings["matkhaumail"]);
                client.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
                client.Host = "smtp.gmail.com";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Send(msg);
                result = true;

            }
            catch(Exception ex)
            {
                result = false;
            }
            return result;

        }
        public bool sendMail(string title, string toMail, string content)
        {
            bool result = false;
            try
            {
                //goi mail
                MailMessage mail = new MailMessage();
            mail.To.Add(toMail);// dia chi nhan
            mail.From = new MailAddress(ConfigurationManager.AppSettings["email"]);//dia chi gui
            mail.Subject = title;//tieu de mail
            mail.Body = content;// noi dung mail
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";// host cua mail
            smtp.Port = 587;//port cua mail
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["email"], ConfigurationManager.AppSettings["matkhaumail"]);//tai khoan,pass nguoi gui
            smtp.EnableSsl = true;
            smtp.Send(mail);
                result = true;

            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}