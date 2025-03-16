using HabitFlow.Api.Abstractions;
using HabitFlow.Application.Users.RegisterUser;
using MediatR;

namespace HabitFlow.Api.Users;

internal sealed class Register : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/users/register", async (Request request, ISender sender) =>
        {
            if (request.Email is not null && request.Password is not null)
            {
                var result = await sender.Send(
                    new RegisterUserCommand(request.Email, request.Password, request.FirstName, request.LastName));

                if (result.IsSuccess)
                {
                    // TODO: Provide location url.
                    return Results.Created("", result.Value);
                }
            }

            return Results.BadRequest();
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
