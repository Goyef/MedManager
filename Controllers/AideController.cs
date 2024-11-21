using System.Net;
using System.Net.Mail;
using ASPBookProject.Services.Interface;
using ASPBookProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPBookProject.Controllers
{
    public class AideController : Controller
    {

      
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Faq()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public  IActionResult Contact()
        {
            return View();
        }

        [HttpPost, ActionName("Contact")]
        public IActionResult ContactPost(MailViewModel viewModel)
        {
            string sender = "bts.testperso@gmail.com";
            string pw = "ppig gflv vmwp ctve";
            string receiver = "saruelucas2@gmail.com";
            string messageComplet = viewModel.Nom + "\n" + viewModel.Prenom  + "\n" + viewModel.email
            + "\n" + viewModel.telephone   + "\n" + viewModel.message;
            MailMessage message = new MailMessage();
            message.From = new MailAddress(sender);
            message.Subject ="Nouveau Message";
            message.To.Add(receiver);
            message.Body= messageComplet;        
            if(!ModelState.IsValid)
                return View(viewModel);
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(sender, pw),
                EnableSsl = true,
            };
            smtpClient.Send(message);
            return RedirectToAction("Index");
        }
    }
}
