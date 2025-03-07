using HabitFlow.Application.Users.RegisterUser;
using MediatR;

namespace HabitFlow.Api.Users;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        app.MapPost("/users/register", async (Request request, ISender sender) => 
        {
            if (request.Email is not null && request.Password is not null)
            {
                var result = await sender.Send(
                    new RegisterUserCommand(request.Email, request.Password, request.FirstName, request.LastName));
            }
        });

    }

    internal sealed class Request
    {
        public string? Email { get; init; }
        public string? Password { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
}
