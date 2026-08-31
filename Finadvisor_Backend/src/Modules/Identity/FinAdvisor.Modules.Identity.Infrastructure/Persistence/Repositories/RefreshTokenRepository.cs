using FinAdvisor.Modules.Identity.Domain.Users.RefreshTokens;
using Microsoft.EntityFrameworkCore;
using FinAdvisor.Modules.Identity.Application.Abstractions.Persistence;

namespace FinAdvisor.Modules.Identity.Infrastructure.Persistence.Repositories
{
    internal sealed class RefreshTokenRepository
    : IRefreshTokenRepository
    {
        private readonly IdentityDbContext _dbContext;

        public RefreshTokenRepository(
            IdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<RefreshToken?> GetByTokenHashAsync(
            string tokenHash,
            CancellationToken cancellationToken = default)
        {
            return _dbContext.RefreshTokens
                .SingleOrDefaultAsync(
                    x => x.TokenHash == tokenHash,
                    cancellationToken);
        }
        

        public void Add(
            RefreshToken refreshToken)
        {
            _dbContext.RefreshTokens.Add(refreshToken);
        }
        public void Remove(RefreshToken refreshToken)
        {
            _dbContext.Remove(refreshToken);
        }
    }
}
