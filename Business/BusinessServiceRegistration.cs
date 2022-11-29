using Microsoft.Extensions.DependencyInjection;
using WebNetSample.Business.Startup;

namespace WebNetSample.Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services,
                                                            AppSettings appSettings)
    {
        services.AddSingleton(appSettings);

        return services;
    }
}