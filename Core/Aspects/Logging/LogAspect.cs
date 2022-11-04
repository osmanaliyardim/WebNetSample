using Castle.DynamicProxy;
using WebNetSample.Core.CrossCuttingConcerns.Logging;

namespace WebNetSample.Core.Aspects.Logging;

public class LogAspect : BaseLogAspect
{
    public LogAspect(Type loggerService) : base(loggerService)
    {
    }

    protected override void OnBefore(IInvocation invocation)
    {
        _loggerServiceBase.Info(GetLogDetail<LogDetail>(invocation));
    }
}
