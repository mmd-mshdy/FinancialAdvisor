namespace FinAdvisor.BuildingBlocks.Application.Validation;

using BuildingBlocks.Domain.Results;
public abstract class Validator<T> : IValidator<T>
{
    public abstract ValidationResult Validate(T instance);

    protected static ValidationResult Success() =>
        ValidationResult.Success();

    protected static ValidationResult Failure(
        params ValidationFailure[] errors) =>
        ValidationResult.Failure(errors);
}