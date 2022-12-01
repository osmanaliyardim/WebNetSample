using NetEscapades.Configuration.Validation;
using System.ComponentModel.DataAnnotations;
using WebNetSample.Business.ValidationRules;

namespace WebNetSample.Business.Startup;

public class SmtpClientSettings : IValidatable
{
    [DefaultValue]
    public string Host { get; set; }

    [DefaultValue]
    public int Port { get; set; }

    [DefaultValue]
    public string EmailName { get; set; }

    [DefaultValue]
    public string EmailAddress { get; set; }

    [DefaultValue]
    public string Password { get; set; }

    [DefaultValue]
    public bool UseSsl { get; set; }

    public void Validate()
    {
        Validator.ValidateObject(this, new ValidationContext(this), true);
    }
}