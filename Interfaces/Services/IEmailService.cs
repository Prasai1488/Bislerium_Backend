using BisleriumBloggers.DTOs.Email;

namespace BisleriumBloggers.Interfaces.Services;

public interface IEmailService
{
    void SendEmail(EmailDto email);
}
