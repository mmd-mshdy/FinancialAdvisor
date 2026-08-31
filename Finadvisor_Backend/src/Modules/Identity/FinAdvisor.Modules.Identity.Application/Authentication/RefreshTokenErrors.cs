using FinAdvisor.BuildingBlocks.Domain.Results;

namespace FinAdvisor.Modules.Identity.Application.Authentication
{
    public static class RefreshTokenErrors
    {
        public static readonly Error Invalid =
            Error.Unauthorized(
                "RefreshTokens.Invalid",
                "The refresh token is invalid or expired.");
    }
}
