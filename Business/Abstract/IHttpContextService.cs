using System.Security.Claims;

namespace WebNetSample.Business.Abstract;

public interface IHttpContextService
{
    Task SignInUsingCookiesAsync(ClaimsPrincipal user);

    string GenerateConfirmEmailLink(string email, string token);

    string GenerateGetUserLink(Guid id);
}
