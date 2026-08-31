using FinAdvisor.BuildingBlocks.Application.Messaging;
using FinAdvisor.BuildingBlocks.Domain.Results;
using FinAdvisor.Modules.Identity.Application.Abstractions.Persistence;
using FinAdvisor.Modules.Identity.Domain.Users;

namespace FinAdvisor.Modules.Identity.Application.Users.UpdateProfile;

internal sealed class UpdateProfileCommandHandler
    : ICommandHandler<UpdateProfileCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProfileCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        UpdateProfileCommand command,
        CancellationToken cancellationToken)
    {
        User? user =
            await _userRepository.GetByIdAsync(
                command.UserId,
                cancellationToken);

        if (user is null)
        {
            return Result.Failure(
                UserErrors.NotFound(command.UserId));
        }

        user.UpdateProfile(
            command.FirstName,
            command.LastName);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result.Success();
    }
}