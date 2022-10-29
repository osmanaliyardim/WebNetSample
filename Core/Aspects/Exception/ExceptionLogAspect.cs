using Castle.DynamicProxy;
using WebNetSample.Core.Aspects.Logging;
using WebNetSample.Core.CrossCuttingConcerns.Logging;
using Error = System.Exception;

namespace WebNetSample.Core.Aspects.Exception;

public class ExceptionLogAspect : BaseLogAspect
{
    public ExceptionLogAspect(Type loggerService) : base(loggerService)
    {
    }

    protected override void OnException(IInvocation invocation, Error e)
    {
        var logDetailWithException = GetLogDetail<LogDetailWithException>(invocation);
        logDetailWithException.ExceptionMessage = e.Message;
        _loggerServiceBase.Error(logDetailWithException);
    }
}