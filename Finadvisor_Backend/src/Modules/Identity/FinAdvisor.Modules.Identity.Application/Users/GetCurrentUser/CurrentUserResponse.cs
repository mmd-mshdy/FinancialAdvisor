namespace FinAdvisor.Modules.Identity.Application.Users.GetCurrentUser;

public sealed record CurrentUserResponse(
    Guid Id,
    string Email,
    string FirstName,
    string LastName);