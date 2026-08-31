using FinAdvisor.BuildingBlocks.Application.Messaging;
using FinAdvisor.BuildingBlocks.Domain.Results;
using FinAdvisor.Modules.Identity.Application.Abstractions.Authentication;
using FinAdvisor.Modules.Identity.Application.Abstractions.Persistence;
using FinAdvisor.Modules.Identity.Domain.Users;

namespace FinAdvisor.Modules.Identity.Application.Users.ChangePassword;

internal sealed class ChangePasswordCommandHandler
    : ICommandHandler<ChangePasswordCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public ChangePasswordCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        ChangePasswordCommand command,
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

        bool currentPasswordIsValid =
            _passwordHasher.Verify(
                command.CurrentPassword,
                user.PasswordHash);

        if (!currentPasswordIsValid)
        {
            return Result.Failure(
                UserErrors.InvalidPassword);
        }

        string newPasswordHash =
            _passwordHasher.Hash(command.NewPassword);

        user.ChangePassword(newPasswordHash);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result.Success();
    }
}