using Microsoft.AspNetCore.Identity;
using FinAdvisor.Modules.Identity.Application.Abstractions.Authentication;

namespace FinAdvisor.Modules.Identity.Infrastructure.Authentication;

internal sealed class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<object> _passwordHasher = new();

    public string Hash(string password)
    {
        return _passwordHasher.HashPassword(
            user: null!,
            password);
    }

    public bool Verify(
        string password,
        string passwordHash)
    {
        PasswordVerificationResult result =
            _passwordHasher.VerifyHashedPassword(
                user: null!,
                passwordHash,
                password);

        return result is
            PasswordVerificationResult.Success
            or PasswordVerificationResult.SuccessRehashNeeded;
    }
}