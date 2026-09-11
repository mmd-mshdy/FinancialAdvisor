using FinAdvisor.API.Extensions;
using FinAdvisor.BuildingBlocks.Domain.Results;
using FinAdvisor.Modules.Identity.Application.Authentication;
using FinAdvisor.Modules.Identity.Application.Authentication.RefreshToken;
using MediatR;

namespace FinAdvisor.API.Endpoints.Identity;

internal static class RefreshToken
{
    internal sealed record Request(
        string RefreshToken);

    public static void MapEndpoint(
        IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/refresh-token",
            async (
                Request request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command =
                    new RefreshTokenCommand(
                        request.RefreshToken);

                Result<AuthenticationResponse> result =
                    await sender.Send(
                        command,
                        cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value)
                    : result.ToProblem();
            });
    }
}