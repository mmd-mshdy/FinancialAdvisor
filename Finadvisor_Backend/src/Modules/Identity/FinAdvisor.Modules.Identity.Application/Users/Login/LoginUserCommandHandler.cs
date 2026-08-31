using FinAdvisor.BuildingBlocks.Application.Messaging;
using FinAdvisor.BuildingBlocks.Domain.Results;
using FinAdvisor.Modules.Identity.Application.Abstractions.Authentication;
using FinAdvisor.Modules.Identity.Application.Abstractions.Persistence;
using FinAdvisor.Modules.Identity.Domain.Users;

namespace FinAdvisor.Modules.Identity.Application.Users.Login;

internal sealed class LoginUserCommandHandler
    : ICommandHandler<LoginUserCommand, AuthenticationResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenProvider _tokenProvider;

    public LoginUserCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        ITokenProvider tokenProvider)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenProvider = tokenProvider;
    }

    public async Task<Result<AuthenticationResponse>> Handle(
        LoginUserCommand command,
        CancellationToken cancellationToken)
    {
        User? user =
            await _userRepository.GetByEmailAsync(
                command.Email,
                cancellationToken);

        if (user is null)
        {
            return Result.Failure<AuthenticationResponse>(
                UserErrors.InvalidCredentials);
        }

        bool passwordIsValid =
            _passwordHasher.Verify(
                command.Password,
                user.PasswordHash);

        if (!passwordIsValid)
        {
            return Result.Failure<AuthenticationResponse>(
                UserErrors.InvalidCredentials);
        }

        AccessToken accessToken =
            _tokenProvider.GenerateAccessToken(user);

        string refreshToken =
            _tokenProvider.GenerateRefreshToken();

        return new AuthenticationResponse(
            user.Id,
            accessToken.Value,
            refreshToken,
            accessToken.ExpiresAt);
    }
}