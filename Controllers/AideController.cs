using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

namespace ASPBookProject.Controllers
{
    public class AideController : Controller
    {
        // GET: AideController
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Faq()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string to, string subject, string body)
        {
            try
            {
                MailMessage email = new MailMessage();
                email.From = new MailAddress("expediteur@tutoriel.fr");
                email.To.Add(new MailAddress(to));
                email.Subject = subject;
                email.Body = body;

                SmtpClient smtp = new SmtpClient("smtp.votre-serveur-smtp.com");
                smtp.Credentials = new NetworkCredential("votre-email@tutoriel.fr", "votre-mot-de-passe");
                smtp.Send(email);

                ViewBag.Message = "Email envoyé avec succès!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Erreur lors de l'envoi de l'email: " + ex.Message;
            }

            return View();
        }
    }
}
