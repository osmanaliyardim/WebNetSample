using Castle.DynamicProxy;
using WebNetSample.Core.CrossCuttingConcerns.Logging;
using WebNetSample.Core.CrossCuttingConcerns.Logging.Log4Net;
using WebNetSample.Core.Utilities.Interceptors;

namespace Core.Aspects.Logging;

public abstract class BaseLogAspect : MethodInterception
{
    protected LoggerServiceBase _loggerServiceBase;

    public BaseLogAspect(Type loggerService)
    {
        if (loggerService.BaseType != typeof(LoggerServiceBase))
        {
            throw new Exception("Wrong validation type!");
        }

        _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
    }

    protected virtual T GetLogDetail<T>(IInvocation invocation) where T : LogDetail, new()
    {
        var logParameters = new List<LogParameter>();

        for (int i = 0; i < invocation.Arguments.Length; i++)
        {
            logParameters.Add(new LogParameter
            {
                Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                Value = invocation.Arguments[i],
                Type = invocation.Arguments[i].GetType().Name
            });
        }

        var logDetail = new T
        {
            MethodName = invocation.Method.Name,
            LogParameters = logParameters,
            FolderLocation = Directory.GetCurrentDirectory()
        };

        return logDetail;
    }
}