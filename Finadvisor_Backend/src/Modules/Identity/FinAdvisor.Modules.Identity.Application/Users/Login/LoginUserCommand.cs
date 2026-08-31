using FinAdvisor.BuildingBlocks.Application.Messaging;
using FinAdvisor.Modules.Identity.Application.Authentication;

namespace FinAdvisor.Modules.Identity.Application.Users.Login;

public sealed record LoginUserCommand(
    string Email,
    string Password)
    : ICommand<AuthenticationResponse>;