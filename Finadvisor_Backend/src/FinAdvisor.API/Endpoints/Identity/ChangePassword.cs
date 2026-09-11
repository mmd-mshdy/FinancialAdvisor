using FinAdvisor.API.Extensions;
using FinAdvisor.Modules.Identity.Application.Users.ChangePassword;
using MediatR;

namespace FinAdvisor.API.Endpoints.Identity;

internal static class ChangePassword
{
    internal sealed record Request(
        string CurrentPassword,
        string NewPassword);

    public static void MapEndpoint(
        IEndpointRouteBuilder app)
    {
        app.MapPut(
            "/change-password",
            async (
                Request request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command =
                    new ChangePasswordCommand(
                        request.CurrentPassword,
                        request.NewPassword);

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