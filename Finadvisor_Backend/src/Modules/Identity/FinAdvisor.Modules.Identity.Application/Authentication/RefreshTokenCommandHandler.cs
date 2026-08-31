using FinAdvisor.BuildingBlocks.Application.Messaging;
using FinAdvisor.BuildingBlocks.Domain.Results;
using FinAdvisor.Modules.Identity.Application.Abstractions.Authentication;
using FinAdvisor.Modules.Identity.Application.Abstractions.Persistence;
using FinAdvisor.Modules.Identity.Application.Authentication;
using FinAdvisor.Modules.Identity.Application.Authentication.RefreshToken;
using FinAdvisor.Modules.Identity.Domain.Users;
using FinAdvisor.Modules.Identity.Domain.Users.RefreshTokens;


internal sealed class RefreshTokenCommandHandler
    : ICommandHandler<RefreshTokenCommand, AuthenticationResponse>
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITokenProvider _tokenProvider;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRefreshTokenHasher _refreshTokenHasher;
    public RefreshTokenCommandHandler(
        IRefreshTokenRepository refreshTokenRepository,
        IUserRepository userRepository,
        ITokenProvider tokenProvider,
        IUnitOfWork unitOfWork,
        IRefreshTokenHasher refreshTokenHasher)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _userRepository = userRepository;
        _tokenProvider = tokenProvider;
        _unitOfWork = unitOfWork;
        _refreshTokenHasher = refreshTokenHasher;
    }

    public async Task<Result<AuthenticationResponse>> Handle(
        RefreshTokenCommand command,
        CancellationToken cancellationToken)
    {
        string tokenHash =
            _refreshTokenHasher.Hash(
                command.RefreshToken);

        RefreshToken? existingToken =
            await _refreshTokenRepository.GetByTokenHashAsync(
                tokenHash,
                cancellationToken);

        if (existingToken is null ||
            !existingToken.IsActive)
        {
            return Result.Failure<AuthenticationResponse>(
                RefreshTokenErrors.Invalid);
        }

        User? user =
            await _userRepository.GetByIdAsync(
                existingToken.UserId,
                cancellationToken);

        if (user is null)
        {
            return Result.Failure<AuthenticationResponse>(
                RefreshTokenErrors.Invalid);
        }

        existingToken.Revoke();

        AccessToken accessToken =
            _tokenProvider.GenerateAccessToken(user);

        RefreshTokenData newRefreshTokenData =
            _tokenProvider.GenerateRefreshToken();

        string newTokenHash =
            _refreshTokenHasher.Hash(
                newRefreshTokenData.Token);

        RefreshToken newRefreshToken =
            RefreshToken.Create(
                user.Id,
                newTokenHash,
                newRefreshTokenData.ExpiresAt);

        _refreshTokenRepository.Add(newRefreshToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return new AuthenticationResponse(
            user.Id,
            accessToken.Value,
            newRefreshTokenData.Token,
            accessToken.ExpiresAt);
    }
}