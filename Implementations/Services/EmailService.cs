using BisleriumBloggers.DTOs.Email;
using BisleriumBloggers.Interfaces.Services;
using System.Net.Mail;
using System.Net;

namespace BisleriumBloggers.Implementations.Services;

public class EmailService : IEmailService
{
    public void SendEmail(EmailDto email)
    {
        const string fromMail = "alexdhital120@gmail.com";

        const string fromPassword = "awcqnyeyhmuehyen";

        var message = new MailMessage
        {
            From = new MailAddress(fromMail),
            Subject = email.Subject,
            Body = "<html><body> " + email.Message + " </body></html>",
            IsBodyHtml = true,
        };

        message.To.Add(new MailAddress(email.Email));

        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromMail, fromPassword),
            EnableSsl = true,
        };

        smtpClient.Send(message);
    }
}