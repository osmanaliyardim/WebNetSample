using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Net;
using WebNetSample.Core.CrossCuttingConcerns.Logging;
using WebNetSample.Core.CrossCuttingConcerns.Logging.Log4Net;

namespace WebNetSample.Core.Extensions;

public class ExceptionMiddleware
{
    private RequestDelegate _next;
    private LoggerServiceBase _loggerServiceBase;

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
            await HandleExceptionAsync(httpContext, e);
        }
    }

    private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        string message = "Internal Server Error";

        IEnumerable<ValidationFailure> errors;

        // DENEME - BAŞLANGIÇ -------------------------------------------------------------------------------------
        var logParameters = new List<LogParameter>();
        logParameters.Add(new LogParameter
        {
            Name = "Osman Ali",
            Value = "YARDIM",
            Type = "EPAM Mentoring 2022 Fall"
        });

        var logDetail = new LogDetail
        {
            MethodName = "Dzimtry Yaniuk",
            LogParameters = logParameters,
            FolderLocation = @"C:\Users\Osman Ali\Desktop\WebNetSample\WebNetSample\wwwroot\XmlData"
        };

        _loggerServiceBase.Fatal(logDetail);
        // DENEME - BİTİŞ -------------------------------------------------------------------------------------

        if (e.GetType() == typeof(ValidationException))
        {
            message = e.Message;
            errors = ((ValidationException)e).Errors;
            httpContext.Response.StatusCode = 400;

            return httpContext.Response.WriteAsync(new ValidationErrorDetails
            {
                StatusCode = 400,
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