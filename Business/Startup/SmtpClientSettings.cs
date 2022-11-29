using NetEscapades.Configuration.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebNetSample.Business.Startup;

public class SmtpClientSettings : IValidatable
{
    public string Host { get; set; }

    public int Port { get; set; }

    public string EmailName { get; set; }

    public string EmailAddress { get; set; }

    public string Password { get; set; }

    public bool UseSsl { get; set; }

    public void Validate()
    {
        Validator.ValidateObject(this, new ValidationContext(this), true);
    }
}