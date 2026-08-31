using FinAdvisor.BuildingBlocks.Domain.Results;

namespace FinAdvisor.BuildingBlocks.Application.Validation;

public sealed class ValidationResult
{
    private ValidationResult(
        bool isValid,
        IReadOnlyCollection<ValidationFailure> errors)
    {
        IsValid = isValid;
        Errors = errors;
    }

    public bool IsValid { get; }

    public bool IsFailure => !IsValid;

    public IReadOnlyCollection<ValidationFailure> Errors { get; }

    public static ValidationResult Success() =>
        new(
            true,
            Array.Empty<ValidationFailure>());

    public static ValidationResult Failure(
        IEnumerable<ValidationFailure> errors)
    {
        ValidationFailure[] errorArray =
            errors.ToArray();

        if (errorArray.Length == 0)
        {
            throw new ArgumentException(
                "A failed validation result must contain at least one error.",
                nameof(errors));
        }

        return new ValidationResult(
            false,
            errorArray);
    }
}