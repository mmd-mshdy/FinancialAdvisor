namespace FinAdvisor.Modules.Identity.Application.Abstractions.Authentication
{
    public sealed record RefreshTokenData(
    string Token,
    DateTime ExpiresAt);
}