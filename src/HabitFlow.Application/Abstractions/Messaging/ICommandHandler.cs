using HabitFlow.SharedKernel;
using MediatR;

namespace HabitFlow.Application.Abstractions.Messaging;
internal interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand;

internal interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>;
