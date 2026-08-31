namespace FinAdvisor.Modules.Identity.Application.Authentication;

public sealed record AuthenticationResponse(
    Guid UserId,
    string AccessToken,
    string RefreshToken,
    DateTime AccessTokenExpiresAt);