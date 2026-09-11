using FinAdvisor.API.Extensions;
using FinAdvisor.Modules.Identity.Application.Users.UpdateProfile;
using MediatR;

namespace FinAdvisor.API.Endpoints.Identity;

internal static class UpdateProfile
{
    internal sealed record Request(
        string FirstName,
        string LastName);

    public static void MapEndpoint(
        IEndpointRouteBuilder app)
    {
        app.MapPut(
            "/profile",
            async (
                Request request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command =
                    new UpdateProfileCommand(
                        request.FirstName,
                        request.LastName);

                var result =
                    await sender.Send(
                        command,
                        cancellationToken);

                return result.IsSuccess
                    ? Results.NoContent()
                    : result.ToProblem();
            })
            .RequireAuthorization();
    }
}