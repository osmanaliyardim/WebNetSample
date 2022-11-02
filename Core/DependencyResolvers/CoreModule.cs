using Microsoft.Extensions.DependencyInjection;
using WebNetSample.Core.CrossCuttingConcerns.Caching;
using WebNetSample.Core.CrossCuttingConcerns.Caching.Microsoft;
using WebNetSample.Core.Utilities.IoC;

namespace WebNetSample.Core.DependencyResolvers;

public class CoreModule : ICoreModule
{
    public void Load(IServiceCollection serviceCollection)
    {
        serviceCollection.AddMemoryCache();

        serviceCollection.AddSingleton<ICacheService, MemoryCacheManager>();
    }
}