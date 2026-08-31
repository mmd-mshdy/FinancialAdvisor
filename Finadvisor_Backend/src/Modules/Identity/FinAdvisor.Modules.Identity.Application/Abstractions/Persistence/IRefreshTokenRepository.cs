using FinAdvisor.Modules.Identity.Domain.Users.RefreshTokens;

namespace FinAdvisor.Modules.Identity.Application.Abstractions.Persistence
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> GetByTokenHashAsync(
        string tokenHash,
        CancellationToken cancellationToken = default);

        void Add(RefreshToken refreshToken);

        void Remove(RefreshToken refreshToken);
    }
}