using FinAdvisor.BuildingBlocks.Application.Messaging;
using FinAdvisor.BuildingBlocks.Domain.Results;
using FinAdvisor.Modules.Identity.Application.Abstractions.Authentication;
using FinAdvisor.Modules.Identity.Application.Abstractions.Persistence;
using FinAdvisor.Modules.Identity.Application.Authentication;
using FinAdvisor.Modules.Identity.Domain.Users;
using FinAdvisor.Modules.Identity.Domain.Users.RefreshTokens;

namespace FinAdvisor.Modules.Identity.Application.Users.Login;

internal sealed class LoginUserCommandHandler
    : ICommandHandler<LoginUserCommand, AuthenticationResponse>
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenProvider _tokenProvider;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRefreshTokenHasher _refreshTokenHasher;



    public LoginUserCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        ITokenProvider tokenProvider,
        IRefreshTokenRepository refreshTokenRepository,
        IUnitOfWork unitOfWork,
        IRefreshTokenHasher refreshTokenHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenProvider = tokenProvider;
        _refreshTokenRepository = refreshTokenRepository;
        _unitOfWork = unitOfWork;
        _refreshTokenHasher = refreshTokenHasher;
    }

    public async Task<Result<AuthenticationResponse>> Handle(
        LoginUserCommand command,
        CancellationToken cancellationToken)
    {
        string email = command.Email.Trim().ToLowerInvariant();
        User? user =
            await _userRepository.GetByEmailAsync(
                email,
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

        RefreshTokenData refreshTokenData =
            _tokenProvider.GenerateRefreshToken();

        string tokenHash =
            _refreshTokenHasher.Hash(
                refreshTokenData.Token);

        RefreshToken refreshToken =
            RefreshToken.Create(
                user.Id,
                tokenHash,
                refreshTokenData.ExpiresAt);

        _refreshTokenRepository.Add(refreshToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return new AuthenticationResponse(
            user.Id,
            accessToken.Value,
            refreshTokenData.Token,
            accessToken.ExpiresAt);
    }
}