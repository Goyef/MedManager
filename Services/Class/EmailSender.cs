using System;
using System.Net;
using System.Net.Mail;
using ASPBookProject.Services.Interface;

namespace ASPBookProject.Services.Class;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string message)
    {
        var mail = "sarue.lucas@outlook.com";
        var pw = "btsap2test";

        var client = new SmtpClient("smtp-mail.outlook.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(mail,pw)
        };

        return client.SendMailAsync(
            new MailMessage(from: mail,
                            to: email,
                            subject,
                            message)
        );
    }

}
