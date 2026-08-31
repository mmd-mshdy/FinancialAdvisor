namespace FinAdvisor.Modules.Identity.Application.Users.Login;

public sealed record AuthenticationResponse(
    Guid UserId,
    string AccessToken,
    string RefreshToken,
    DateTime AccessTokenExpiresAt);