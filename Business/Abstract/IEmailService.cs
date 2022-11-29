namespace WebNetSample.Business.Abstract;

public interface IEmailService
{
    Task SendEmailAsync(string emailToSend, string subject, string message);
}