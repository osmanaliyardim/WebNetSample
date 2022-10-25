using Castle.DynamicProxy;
using WebNetSample.Core.CrossCuttingConcerns.Logging;

namespace Core.Aspects.Logging;

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
