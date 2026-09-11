using FinAdvisor.BuildingBlocks.Application.Messaging;

namespace FinAdvisor.Modules.Identity.Application.Users.GetCurrentUser;

public sealed record GetCurrentUserQuery
    : IQuery<CurrentUserResponse>;