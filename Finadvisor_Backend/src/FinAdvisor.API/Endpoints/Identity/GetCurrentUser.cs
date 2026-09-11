using FinAdvisor.API.Extensions;
using FinAdvisor.BuildingBlocks.Domain.Results;
using FinAdvisor.Modules.Identity.Application.Users.GetCurrentUser;
using MediatR;

namespace FinAdvisor.API.Endpoints.Identity;

internal static class GetCurrentUser
{
    public static void MapEndpoint(
        IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/me",
            async (
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query =
                    new GetCurrentUserQuery();

                Result<CurrentUserResponse> result =
                    await sender.Send(
                        query,
                        cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value)
                    : result.ToProblem();
            })
            .RequireAuthorization();
    }
}