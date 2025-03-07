using HabitFlow.Application.Abstractions.Messaging;

namespace HabitFlow.Application.Users.RegisterUser;
public sealed record RegisterUserCommand(string Email, string Password, string FirstName, string LastName) : ICommand<Guid>;
