namespace FinAdvisor.Modules.Identity.Application.Abstractions.Authentication;

public sealed record AccessToken(
    string Value,
    DateTime ExpiresAt);