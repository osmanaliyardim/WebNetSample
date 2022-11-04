using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Diagnostics;
using WebNetSample.Core.Extensions;

namespace WebNetSample.WebNetMVC.Middlewares;

public static class ExceptionMiddlawareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature != null)
                {
                    await HandleExceptionAsync(context, contextFeature);
                }
            });
        });

        Task HandleExceptionAsync(HttpContext httpContext, IExceptionHandlerFeature exceptionHandlerFeature)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var message = "Internal Server Error";

            if (exceptionHandlerFeature?.Error is ValidationException)
            {
                IEnumerable<ValidationFailure> errors;

                message = exceptionHandlerFeature.Error.Message;
                errors = ((ValidationException)exceptionHandlerFeature).Errors;
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