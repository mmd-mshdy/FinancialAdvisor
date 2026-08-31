using FinAdvisor.Modules.Identity.Domain.Users;

namespace FinAdvisor.Modules.Identity.Application.Abstractions.Authentication;

public interface ITokenProvider
{
    AccessToken GenerateAccessToken(User user);

    RefreshTokenData GenerateRefreshToken();
}