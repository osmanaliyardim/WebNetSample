using Microsoft.Extensions.DependencyInjection;

namespace WebNetSample.Core.Utilities.IoC;

public interface ICoreModule
{
    void Load(IServiceCollection serviceCollection);
}