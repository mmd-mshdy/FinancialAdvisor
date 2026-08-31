namespace FinAdvisor.BuildingBlocks.Domain.Results;

public sealed record ValidationError(
    IReadOnlyCollection<ValidationFailure> Errors)
    : Error(
        "General.Validation",
        "One or more validation errors occurred.",
        ErrorType.Validation);