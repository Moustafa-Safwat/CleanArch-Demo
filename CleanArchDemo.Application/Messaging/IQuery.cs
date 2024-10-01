using CleanArchDemo.Core.Shared;
using MediatR;

namespace CleanArchDemo.Application.Messaging;

public interface IQuery<TResult> : IRequest<Result<TResult>>
{
}