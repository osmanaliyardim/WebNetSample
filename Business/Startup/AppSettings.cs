using NetEscapades.Configuration.Validation;

namespace WebNetSample.Business.Startup;

public class AppSettings : IValidatable
{
    public SmtpClientSettings SmtpClientSettings { get; set; }

    public void Validate()
    {
        this.SmtpClientSettings.Validate();
    }
}
