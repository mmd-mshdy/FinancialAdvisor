using FinAdvisor.BuildingBlocks.Application.Messaging;

namespace FinAdvisor.Modules.Identity.Application.Users.Login;

public sealed record LoginUserCommand(
    string Email,
    string Password)
    : ICommand<AuthenticationResponse>;