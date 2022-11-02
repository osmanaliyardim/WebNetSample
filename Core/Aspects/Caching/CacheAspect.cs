using Castle.DynamicProxy;
using WebNetSample.Core.CrossCuttingConcerns.Caching;
using WebNetSample.Core.Utilities.Interceptors;
using WebNetSample.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace WebNetSample.Core.Aspects.Caching;

public class CacheAspect : MethodInterception
{
    private readonly ICacheService _cacheService;
    public readonly int duration;

    public string Location { get; set; } = "Client";

    public CacheAspect(int duration = 60)
    {
        this.duration = duration;
        _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
    }

    public override void Intercept(IInvocation invocation)
    {
        var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
        var arguments = invocation.Arguments.ToList();
        var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";

        if (_cacheService.IsAdded(key))
        {
            invocation.ReturnValue = _cacheService.Get(key);
            return;
        }

        invocation.Proceed();
        _cacheService.Add(key, invocation.ReturnValue, duration);
    }
}