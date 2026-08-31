using FinAdvisor.Modules.Identity.Application.Abstractions.Authentication;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FinAdvisor.Modules.Identity.Infrastructure.Authentication
{
    internal sealed class RefreshTokenHasher : IRefreshTokenHasher
    {
        public string Hash(string token)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(token);
            byte[] hash = SHA256.HashData(bytes);
            return Convert.ToHexString(hash);
        }
    }
}
