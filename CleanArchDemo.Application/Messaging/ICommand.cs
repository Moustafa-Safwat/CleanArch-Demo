using CleanArchDemo.Core.Shared;
using MediatR;

namespace CleanArchDemo.Application.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResult> : IRequest<Result<TResult>>
{
}
