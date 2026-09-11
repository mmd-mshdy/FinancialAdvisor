using FinAdvisor.BuildingBlocks.Application.Messaging;
using FinAdvisor.BuildingBlocks.Domain.Results;
using FinAdvisor.Modules.Identity.Application.Abstractions.Authentication;
using FinAdvisor.Modules.Identity.Application.Abstractions.Authetication;
using FinAdvisor.Modules.Identity.Application.Abstractions.Persistence;
using FinAdvisor.Modules.Identity.Domain.Users;

namespace FinAdvisor.Modules.Identity.Application.Users.ChangePassword;

internal sealed class ChangePasswordCommandHandler
    : ICommandHandler<ChangePasswordCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;
    public ChangePasswordCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork,
        IUserContext userContext)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
        _userContext = userContext;
    }

    public async Task<Result> Handle(
        ChangePasswordCommand command,
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