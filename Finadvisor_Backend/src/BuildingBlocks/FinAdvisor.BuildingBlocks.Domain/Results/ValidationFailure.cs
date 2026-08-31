namespace FinAdvisor.BuildingBlocks.Domain.Results;

public sealed record ValidationFailure(
    string PropertyName,
    string Code,
    string Description);