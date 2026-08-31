using FinAdvisor.BuildingBlocks.Application.Messaging;

namespace FinAdvisor.Modules.Identity.Application.Authentication.RefreshToken;

public sealed record RefreshTokenCommand(
    string RefreshToken)
    : ICommand<AuthenticationResponse>;