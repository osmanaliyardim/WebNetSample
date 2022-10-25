using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using WebNetSample.Core.CrossCuttingConcerns.Logging.Log4Net;

namespace WebNetSample.Core.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly LoggerServiceBase _loggerServiceBase;

        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
            _loggerServiceBase = new LoggerServiceBase("JsonFileLogger");
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                _loggerServiceBase.Fatal(e);
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var message = "Internal Server Error";

            if (e.GetType() == typeof(ValidationException))
            {
                IEnumerable<ValidationFailure> errors;

                message = e.Message;
                errors = ((ValidationException)e).Errors;
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                return httpContext.Response.WriteAsync(new ValidationErrorDetails
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = message,
                    Errors = errors
                }.ToString());
            }

            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}