using FinAdvisor.BuildingBlocks.Application.Validation;
using FinAdvisor.BuildingBlocks.Domain.Results;

namespace FinAdvisor.Modules.Identity.Application.Users.Login;

internal sealed class LoginUserCommandValidator
    : Validator<LoginUserCommand>
{
    public override ValidationResult Validate(
        LoginUserCommand command)
    {
        var errors = new List<ValidationFailure>();

        if (string.IsNullOrWhiteSpace(command.Email))
        {
            errors.Add(
                new ValidationFailure(
                    nameof(command.Email),
                    "Users.Login.EmailRequired",
                    "Email is required."));
        }

        if (string.IsNullOrWhiteSpace(command.Password))
        {
            errors.Add(
                new ValidationFailure(
                    nameof(command.Password),
                    "Users.Login.PasswordRequired",
                    "Password is required."));
        }

        return errors.Count == 0
            ? Success()
            : ValidationResult.Failure(errors);
    }
}