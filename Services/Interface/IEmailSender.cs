using System;

namespace ASPBookProject.Services.Interface;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
}
