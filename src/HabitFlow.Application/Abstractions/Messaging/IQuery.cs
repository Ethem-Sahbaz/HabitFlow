using HabitFlow.SharedKernel;
using MediatR;

namespace HabitFlow.Application.Abstractions.Messaging;
internal interface IQuery<TResponse> : IRequest<Result<TResponse>>;
