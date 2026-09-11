using FinAdvisor.API.Extensions;
using FinAdvisor.BuildingBlocks.Domain.Results;
using FinAdvisor.Modules.Identity.Application.Authentication;
using FinAdvisor.Modules.Identity.Application.Users.Login;
using MediatR;

namespace FinAdvisor.API.Endpoints.Identity;

internal static class Login
{
    internal sealed record Request(
        string Email,
        string Password);

    public static void MapEndpoint(
        IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/login",
            async (
                Request request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command =
                    new LoginUserCommand(
                        request.Email,
                        request.Password);

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