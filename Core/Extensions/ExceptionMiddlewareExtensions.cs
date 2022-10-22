using Microsoft.AspNetCore.Builder;

namespace WebNetSample.Core.Extensions;

public static class ExceptionMiddlawareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}