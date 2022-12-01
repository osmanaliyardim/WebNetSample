using Microsoft.Extensions.Configuration;
using WebNetSample.Business.Startup;

namespace WebNetSample.WebNetMVC.Middlewares;

public static class AppSettingsExtensions
{
    public static AppSettings ReadAppSettings(this IConfiguration configuration)
    {
        var smtpClientSettings = configuration
            .GetSection(nameof(AppSettings.SmtpClientSettings))
            .Get<SmtpClientSettings>();

        return new AppSettings
        {
            SmtpClientSettings = smtpClientSettings
        };
    }
}