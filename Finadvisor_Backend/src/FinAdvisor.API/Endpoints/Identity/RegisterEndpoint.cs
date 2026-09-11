using FinAdvisor.API.Extensions;
using FinAdvisor.BuildingBlocks.Domain.Results;
using FinAdvisor.Modules.Identity.Application.Users.Register;
using MediatR;

namespace FinAdvisor.API.Endpoints.Identity;

internal static class Register
{
    internal sealed record Request(
        string Email,
        string Password,
        string FirstName,
        string LastName);

    public static void MapEndpoint(
        IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/register",
            async (
                Request request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command =
                    new RegisterUserCommand(
                        request.Email,
                        request.Password,
                        request.FirstName,
                        request.LastName);

                Result<Guid> result =
                    await sender.Send(
                        command,
                        cancellationToken);

                return result.IsSuccess
                    ? Results.Created(
                        $"/api/identity/users/{result.Value}",
                        new
                        {
                            UserId = result.Value
                        })
                    : result.ToProblem();
            });
    }
}