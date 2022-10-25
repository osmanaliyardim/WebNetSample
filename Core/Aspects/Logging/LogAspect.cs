using Castle.DynamicProxy;

namespace Core.Aspects.Logging;

public class LogAspect : BaseLogAspect
{
    public LogAspect(Type loggerService) : base(loggerService)
    {
    }

    protected override void OnBefore(IInvocation invocation)
    {
        _loggerServiceBase.Info(GetLogDetail(invocation));
    }
}
