namespace FinAdvisor.API.Endpoints.Identity;

public static class IdentityEndpoints
{
    public static IEndpointRouteBuilder MapIdentityEndpoints(
        this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group =
            app.MapGroup("/api/identity")
                .WithTags("Identity");

        Register.MapEndpoint(group);
        Login.MapEndpoint(group);
        RefreshToken.MapEndpoint(group);

        GetCurrentUser.MapEndpoint(group);
        ChangePassword.MapEndpoint(group);
        UpdateProfile.MapEndpoint(group);

        return app;
    }
}