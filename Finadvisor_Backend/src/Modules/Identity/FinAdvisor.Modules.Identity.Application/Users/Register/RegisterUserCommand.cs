using FinAdvisor.BuildingBlocks.Application.Messaging;

namespace FinAdvisor.Modules.Identity.Application.Users.Register;

public sealed record RegisterUserCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName)
    : ICommand<Guid>;