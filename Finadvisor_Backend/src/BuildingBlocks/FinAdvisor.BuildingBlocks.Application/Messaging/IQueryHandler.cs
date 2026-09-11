using FinAdvisor.BuildingBlocks.Domain.Results;
using MediatR;

namespace FinAdvisor.BuildingBlocks.Application.Messaging;

public interface IQueryHandler<in TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}