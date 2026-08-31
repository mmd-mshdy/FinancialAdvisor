using FinAdvisor.BuildingBlocks.Domain.Results;

namespace FinAdvisor.Modules.Identity.Domain.Users;

public static class UserErrors
{
    public static Error NotFound(Guid userId) =>
        Error.NotFound(
            "Users.NotFound",
            $"The user with the identifier '{userId}' was not found.");

    public static readonly Error EmailAlreadyExists =
        Error.Conflict(
            "Users.EmailAlreadyExists",
            "The specified email address is already in use.");

    public static readonly Error InvalidCredentials =
        Error.Unauthorized(
            "Users.InvalidCredentials",
            "The email or password is incorrect.");

    public static readonly Error InvalidPassword =
        Error.Validation(
            "Users.InvalidPassword",
            "The current password is incorrect.");
}