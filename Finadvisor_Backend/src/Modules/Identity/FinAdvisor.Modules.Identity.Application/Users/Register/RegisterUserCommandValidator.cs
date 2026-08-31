using FinAdvisor.BuildingBlocks.Application.Validation;
using FinAdvisor.BuildingBlocks.Domain.Results;

namespace FinAdvisor.Modules.Identity.Application.Users.Register;

internal sealed class RegisterUserCommandValidator
    : Validator<RegisterUserCommand>
{
    public override ValidationResult Validate(
        RegisterUserCommand command)
    {
        var errors = new List<ValidationFailure>();

        if (string.IsNullOrWhiteSpace(command.Email))
        {
            errors.Add(
                new ValidationFailure(
                    nameof(command.Email),
                    "Users.Register.EmailRequired",
                    "Email is required."));
        }
        else if (!command.Email.Contains('@'))
        {
            errors.Add(
                new ValidationFailure(
                    nameof(command.Email),
                    "Users.Register.InvalidEmail",
                    "The specified email is invalid."));
        }

        if (string.IsNullOrWhiteSpace(command.Password))
        {
            errors.Add(
                new ValidationFailure(
                    nameof(command.Password),
                    "Users.Register.PasswordRequired",
                    "Password is required."));
        }
        else if (command.Password.Length < 8)
        {
            errors.Add(
                new ValidationFailure(
                    nameof(command.Password),
                    "Users.Register.PasswordTooShort",
                    "Password must contain at least 8 characters."));
        }

        if (string.IsNullOrWhiteSpace(command.FirstName))
        {
            errors.Add(
                new ValidationFailure(
                    nameof(command.FirstName),
                    "Users.Register.FirstNameRequired",
                    "First name is required."));
        }

        if (string.IsNullOrWhiteSpace(command.LastName))
        {
            errors.Add(
                new ValidationFailure(
                    nameof(command.LastName),
                    "Users.Register.LastNameRequired",
                    "Last name is required."));
        }

        return errors.Count == 0
            ? Success()
            : ValidationResult.Failure(errors);
    }
}