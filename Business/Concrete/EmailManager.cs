using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using WebNetSample.Business.Abstract;
using WebNetSample.Business.Startup;

namespace WebNetSample.Business.Concrete;

public class EmailManager : IEmailService
{
    private readonly AppSettings _appSettings;

    public EmailManager(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    public async Task SendEmailAsync(string emailToSend, string subject, string message)
    {
        var email = new MimeMessage();

        email.From.Add(new MailboxAddress(
                _appSettings.SmtpClientSettings.EmailName,
                _appSettings.SmtpClientSettings.EmailAddress)
        );
        email.To.Add(new MailboxAddress(string.Empty, emailToSend));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html)
        {
            Text = message,
        };

        using var smtpClient = new SmtpClient();

        await smtpClient.ConnectAsync(
            _appSettings.SmtpClientSettings.Host,
            _appSettings.SmtpClientSettings.Port,
            _appSettings.SmtpClientSettings.UseSsl
        );

        await smtpClient.AuthenticateAsync(
            _appSettings.SmtpClientSettings.EmailAddress,
            _appSettings.SmtpClientSettings.Password
        );
        await smtpClient.SendAsync(email);

        await smtpClient.DisconnectAsync(true);
    }
}