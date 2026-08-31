using FinAdvisor.BuildingBlocks.Application.Messaging;

namespace FinAdvisor.Modules.Identity.Application.Users.ChangePassword;

public sealed record ChangePasswordCommand(
    Guid UserId,
    string CurrentPassword,
    string NewPassword)
    : ICommand;