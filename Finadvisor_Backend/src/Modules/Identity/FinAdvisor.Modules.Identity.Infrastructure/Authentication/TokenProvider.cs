using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinAdvisor.Modules.Identity.Application.Abstractions.Authentication;
using FinAdvisor.Modules.Identity.Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FinAdvisor.Modules.Identity.Infrastructure.Authentication;

internal sealed class TokenProvider : ITokenProvider
{
    private readonly JwtOptions _options;

    public TokenProvider(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public AccessToken GenerateAccessToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityKey =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.SecretKey));

        var credentials =
            new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);

        DateTime expiresAt =
            DateTime.UtcNow.AddMinutes(
                _options.AccessTokenExpirationMinutes);

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: expiresAt,
            signingCredentials: credentials);

        string tokenValue =
            new JwtSecurityTokenHandler()
                .WriteToken(token);

        return new AccessToken(
            tokenValue,
            expiresAt);
    }

    public RefreshTokenData GenerateRefreshToken()
    {
        byte[] randomBytes =
            System.Security.Cryptography.RandomNumberGenerator
                .GetBytes(64);

        string token =
            Convert.ToBase64String(randomBytes);

        return new RefreshTokenData(
            token,
            DateTime.UtcNow.AddDays(
                _options.RefreshTokenExpirationDays));
    }
}