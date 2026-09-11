using MediatR;
using FinAdvisor.BuildingBlocks.Domain.Results;
namespace FinAdvisor.BuildingBlocks.Application.Messaging;

public interface ICommand
    : IRequest<Result>
{
}

public interface ICommand<TResponse>
    : IRequest<Result<TResponse>>
{
}