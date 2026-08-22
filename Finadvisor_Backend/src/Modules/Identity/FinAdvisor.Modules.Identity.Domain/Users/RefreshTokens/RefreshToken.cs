using FinAdvisor.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinAdvisor.Modules.Identity.Domain.Users.RefreshTokens
{
    public sealed class RefreshToken : Entity
    {
        private RefreshToken(Guid id) : base(id) { }

        private RefreshToken(
            Guid id,
            Guid userId,
            string token,
            DateTime expiresAtUtc) :base(id)
        {
            Id = id;
            UserId = userId;
            TokenHash = token;
            ExpiresAtUtc = expiresAtUtc;
            CreatedAtUtc = DateTime.UtcNow;
        }
        public Guid UserId { get; private set; }
        public string TokenHash { get; private set; } = null!;
        public DateTime CreatedAtUtc { get; private set; }
        public DateTime ExpiresAtUtc { get; private set; }
        public DateTime? RevokedAtUtc { get; private set; }
        public bool IsExpired => DateTime.UtcNow >= ExpiresAtUtc;
        public bool IsRevoked =>RevokedAtUtc.HasValue;
        public bool IsActive => !IsExpired && !IsRevoked;
        public static RefreshToken Create(Guid userId ,string token, DateTime expiresAtUtc)
        { 
            return new RefreshToken( Guid.NewGuid(), userId, token,expiresAtUtc);
        }
        public void Revoke()
        {
            if (IsRevoked) return;
            RevokedAtUtc = DateTime.UtcNow;
        }
    }
}
