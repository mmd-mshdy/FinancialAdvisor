using FinAdvisor.BuildingBlocks.Application.Messaging;
using FinAdvisor.BuildingBlocks.Domain.Results;
using FinAdvisor.Modules.Identity.Application.Abstractions.Authentication;
using FinAdvisor.Modules.Identity.Application.Abstractions.Persistence;
using FinAdvisor.Modules.Identity.Domain.Users;

namespace FinAdvisor.Modules.Identity.Application.Users.Register;

internal sealed class RegisterUserCommandHandler
    : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        RegisterUserCommand command,
        CancellationToken cancellationToken)
    {
        User? existingUser =
            await _userRepository.GetByEmailAsync(
                command.Email,
                cancellationToken);

        if (existingUser is not null)
        {
            return Result.Failure<Guid>(
                UserErrors.EmailAlreadyExists);
        }

        string passwordHash =
            _passwordHasher.Hash(command.Password);

        User user = User.Create(
            command.Email,
            passwordHash,
            command.FirstName,
            command.LastName);

        _userRepository.Add(user);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return user.Id;
    }
}