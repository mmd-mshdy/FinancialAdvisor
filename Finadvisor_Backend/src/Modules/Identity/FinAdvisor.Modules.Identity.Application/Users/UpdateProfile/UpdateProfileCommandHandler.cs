using FinAdvisor.BuildingBlocks.Application.Messaging;
using FinAdvisor.BuildingBlocks.Domain.Results;
using FinAdvisor.Modules.Identity.Application.Abstractions.Authetication;
using FinAdvisor.Modules.Identity.Application.Abstractions.Persistence;
using FinAdvisor.Modules.Identity.Domain.Users;

namespace FinAdvisor.Modules.Identity.Application.Users.UpdateProfile;

internal sealed class UpdateProfileCommandHandler
    : ICommandHandler<UpdateProfileCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;
    public UpdateProfileCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IUserContext userContext)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _userContext = userContext;
    }

    public async Task<Result> Handle(
        UpdateProfileCommand command,
        CancellationToken cancellationToken)
    {
        User? user =
            await _userRepository.GetByIdAsync(
               _userContext.UserId,
                cancellationToken);

        if (user is null)
        {
            return Result.Failure(
                UserErrors.NotFound(_userContext.UserId));
        }

        user.UpdateProfile(
            command.FirstName,
            command.LastName);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result.Success();
    }
}