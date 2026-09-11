using FinAdvisor.BuildingBlocks.Domain.Results;

namespace FinAdvisor.BuildingBlocks.Application.Validation;

public sealed class RequestValidationException
    : Exception
{
    public RequestValidationException(
        IReadOnlyCollection<ValidationFailure> errors)
        : base("One or more validation errors occurred.")
    {
        Errors = errors;
    }

    public IReadOnlyCollection<ValidationFailure> Errors { get; }
}