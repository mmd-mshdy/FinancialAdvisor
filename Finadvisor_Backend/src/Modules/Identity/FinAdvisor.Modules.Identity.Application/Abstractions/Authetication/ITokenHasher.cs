namespace FinAdvisor.Modules.Identity.Application.Abstractions.Authentication;

public interface IRefreshTokenHasher
{
    string Hash(string token);
}