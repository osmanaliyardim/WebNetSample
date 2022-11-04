using Castle.DynamicProxy;
using WebNetSample.Core.CrossCuttingConcerns.Caching;
using WebNetSample.Core.Utilities.Interceptors;
using WebNetSample.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace WebNetSample.Core.Aspects.Caching;

public class CacheRemoveAspect : MethodInterception
{
    private readonly ICacheService _cacheService;
    private readonly string _pattern;

    public CacheRemoveAspect(string pattern)
    {
        _pattern = pattern;
        _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
    }

    protected override void OnSuccess(IInvocation invocation)
    {
        _cacheService.RemoveByPattern(_pattern);
    }
}