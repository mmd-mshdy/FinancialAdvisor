using FinAdvisor.BuildingBlocks.Application.Validation;
using FinAdvisor.BuildingBlocks.Domain.Results;
using MediatR;

namespace FinAdvisor.BuildingBlocks.Application.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(
        IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next(cancellationToken);
        }

        ValidationFailure[] failures =
            _validators
                .Select(validator =>
                    validator.Validate(request))
                .Where(result =>
                    result.IsFailure)
                .SelectMany(result =>
                    result.Errors)
                .ToArray();

        if (failures.Length != 0)
        {
            throw new RequestValidationException(
                failures);
        }

        return await next(cancellationToken);
    }
}