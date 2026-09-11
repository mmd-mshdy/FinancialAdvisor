using FinAdvisor.Modules.Identity.Application.Abstractions.Authetication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinAdvisor.Modules.Identity.Infrastructure.Authentication;

internal sealed class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext(
        IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public bool IsAuthenticated =>
        _httpContextAccessor
            .HttpContext?
            .User
            .Identity?
            .IsAuthenticated
        ?? false;

    public Guid UserId
    {
        get
        {
            string? userId =
                _httpContextAccessor
                    .HttpContext?
                    .User
                    .FindFirstValue(
                        ClaimTypes.NameIdentifier);

            if (userId is null ||
                !Guid.TryParse(userId, out Guid parsedUserId))
            {
                throw new InvalidOperationException(
                    "The current user identifier is unavailable.");
            }

            return parsedUserId;
        }
    }
}