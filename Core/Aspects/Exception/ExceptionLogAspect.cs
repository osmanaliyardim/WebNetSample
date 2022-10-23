using Castle.DynamicProxy;
using Core.Aspects.Logging;
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
        var logDetailWithException = GetLogDetail(invocation);
        logDetailWithException.ExceptionMessage = e.Message;
        _loggerServiceBase.Error(logDetailWithException);
    }

    protected override LogDetailWithException GetLogDetail(IInvocation invocation)
    {
        var logParameters = new List<LogParameter>();

        for (int i = 0; i < invocation.Arguments.Length; i++)
        {
            logParameters.Add(new LogParameter
            {
                Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                Value = invocation.Arguments[i],
                Type = invocation.Arguments[i] != null ? invocation.Arguments[i].GetType().Name : ""
            });
        }

        var logDetailWithException = new LogDetailWithException
        {
            MethodName = invocation.Method.Name,
            LogParameters = logParameters,
            FolderLocation = "/Core/CrossCuttingConcerns/Logging/Log4Net"
        };

        return logDetailWithException;
    }
}