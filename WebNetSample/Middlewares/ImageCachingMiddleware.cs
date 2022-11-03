using Microsoft.AspNetCore.ResponseCaching;
using Microsoft.Net.Http.Headers;
using WebNetSample.Core.Aspects.Caching;

namespace WebNetSample.WebNetMVC.Middlewares
{
    public class ImageCachingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly CacheAspect _cacheAspect;

        public ImageCachingMiddleware(
            RequestDelegate next,
            CacheAspect cacheAspect)
        {
            _next = next;
            _cacheAspect = cacheAspect;
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