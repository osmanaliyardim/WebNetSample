using Microsoft.AspNetCore.ResponseCaching;
using Microsoft.Net.Http.Headers;
using WebNetSample.Core.Aspects.Caching;
using WebNetSample.Core.CrossCuttingConcerns.Caching;
using WebNetSample.Core.Utilities.IoC;

namespace WebNetSample.WebNetMVC.Middlewares
{
    public class ImageCachingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly CacheAspect _cacheAspect;
        private readonly ICacheService _cacheService;

        public ImageCachingMiddleware(RequestDelegate next, ICacheService cacheService)
        {
            _next = next;
            _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.GetTypedHeaders().CacheControl =
                new CacheControlHeaderValue()
                {
                    MaxAge = TimeSpan.FromMinutes(_cacheAspect._duration),
                    Private = _cacheAspect.Location == "Client",
                    Public = _cacheAspect.Location == "Any"
                };

            var responseCachingFeature = context.Features.Get<IResponseCachingFeature>();

            if (responseCachingFeature != null)
            {
                responseCachingFeature.VaryByQueryKeys = new[] { "Id" };
            }

            await _next(context);
        }
    }
}