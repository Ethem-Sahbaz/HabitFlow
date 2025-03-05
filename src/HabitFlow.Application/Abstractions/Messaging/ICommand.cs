using HabitFlow.SharedKernel;
using MediatR;

namespace HabitFlow.Application.Abstractions.Messaging;
internal interface ICommand : IRequest<Result>;
internal interface ICommand<TResponse> : IRequest<Result<TResponse>>;
