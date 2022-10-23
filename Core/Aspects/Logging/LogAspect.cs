﻿using Castle.DynamicProxy;
using WebNetSample.Core.CrossCuttingConcerns.Logging;

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

    protected override LogDetail GetLogDetail(IInvocation invocation)
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

        var logDetail = new LogDetail
        {
            MethodName = invocation.Method.Name,
            LogParameters = logParameters,
            FolderLocation = Directory.GetCurrentDirectory()
        };

        return logDetail;
    }
}
