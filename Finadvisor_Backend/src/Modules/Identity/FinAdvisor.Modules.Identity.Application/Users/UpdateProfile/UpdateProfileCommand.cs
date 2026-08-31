using FinAdvisor.BuildingBlocks.Application.Messaging;

namespace FinAdvisor.Modules.Identity.Application.Users.UpdateProfile;

public sealed record UpdateProfileCommand(
    Guid UserId,
    string FirstName,
    string LastName)
    : ICommand;