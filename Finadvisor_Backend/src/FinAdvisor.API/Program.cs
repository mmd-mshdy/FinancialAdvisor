using FinAdvisor.API.Endpoints.Identity;
using FinAdvisor.API.ExceptionHandling;
using FinAdvisor.Modules.Identity.Application;
using FinAdvisor.Modules.Identity.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddIdentityApplication();
builder.Services.AddIdentityModule(
    builder.Configuration);
builder.Services.AddIdentityInfrastructure(
    builder.Configuration);

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<
    ValidationExceptionHandler>();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}
app.UseExceptionHandler();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapIdentityEndpoints();

app.Run();
