using FinAdvisor.BuildingBlocks.Domain.Results;
using MediatR;

namespace FinAdvisor.BuildingBlocks.Application.Messaging;

public interface IQuery<TResponse>
    : IRequest<Result<TResponse>>
{
}