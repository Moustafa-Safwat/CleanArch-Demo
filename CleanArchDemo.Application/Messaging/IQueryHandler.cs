using CleanArchDemo.Core.Shared;
using MediatR;

namespace CleanArchDemo.Application.Messaging;

public interface IQueryHandler<TQuery, TResult>
    : IRequestHandler<TQuery, Result<TResult>>
    where TQuery : IQuery<TResult>
{
}