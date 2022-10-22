using Castle.DynamicProxy;
using WebNetSample.Core.CrossCuttingConcerns.Logging;
using WebNetSample.Core.CrossCuttingConcerns.Logging.Log4Net;
using WebNetSample.Core.Utilities.Interceptors;

namespace Core.Aspects.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new Exception("Wrong logger type!");
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase.Info(GetLogDetail(invocation));
        }

        private LogDetail GetLogDetail(IInvocation invocation)
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
                FolderLocation = @"C:\Users\Osman Ali\Desktop\WebNetSample\WebNetSample\wwwroot\XmlData"
            };

            return logDetail;
        }
    }
}
