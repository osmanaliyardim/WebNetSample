using Microsoft.Extensions.DependencyInjection;
using WebNetSample.Core.Utilities.IoC;

namespace WebNetSample.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, ICoreModule[] modules)
    {
        foreach (var module in modules)
        {
            module.Load(services);
        }

        return ServiceTool.Create(services);
    }
}