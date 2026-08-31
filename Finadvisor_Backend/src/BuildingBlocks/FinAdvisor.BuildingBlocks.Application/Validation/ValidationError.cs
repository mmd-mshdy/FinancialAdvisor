using FinAdvisor.BuildingBlocks.Domain.Results;

namespace FinAdvisor.BuildingBlocks.Application.Validation;

public sealed record ValidationError(
    string PropertyName,
    string Code,
    string Description)
{
    public Error ToError() =>
        Error.Validation(Code, Description);
}