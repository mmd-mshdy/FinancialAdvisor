using FinAdvisor.BuildingBlocks.Application.Messaging;
using FinAdvisor.BuildingBlocks.Domain.Results;
using FinAdvisor.Modules.Identity.Application.Abstractions.Authetication;
using FinAdvisor.Modules.Identity.Application.Abstractions.Persistence;
using FinAdvisor.Modules.Identity.Application.Users.GetCurrentUser;
using FinAdvisor.Modules.Identity.Domain.Users;

internal sealed class GetCurrentUserQueryHandler
    : IQueryHandler<GetCurrentUserQuery, CurrentUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserContext _userContext;

    public GetCurrentUserQueryHandler(
        IUserRepository userRepository,
        IUserContext userContext)
    {
        _userRepository = userRepository;
        _userContext = userContext;
    }

    public async Task<Result<CurrentUserResponse>> Handle(
        GetCurrentUserQuery query,
        CancellationToken cancellationToken)
    {
        User? user =
            await _userRepository.GetByIdAsync(
                _userContext.UserId,
                cancellationToken);

        if (user is null)
        {
            return Result.Failure<CurrentUserResponse>(
                UserErrors.NotFound(
                    _userContext.UserId));
        }

        return new CurrentUserResponse(
            user.Id,
            user.Email,
            user.FirstName,
            user.FamilyName);
    }
}