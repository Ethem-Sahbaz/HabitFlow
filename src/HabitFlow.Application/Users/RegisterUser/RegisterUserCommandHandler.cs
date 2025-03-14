using HabitFlow.Application.Abstractions.Identity;
using HabitFlow.Application.Abstractions.Messaging;
using HabitFlow.SharedKernel;

namespace HabitFlow.Application.Users.RegisterUser;
internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, string>
{
    private readonly IIdentityProviderService _identityProviderService;

    public RegisterUserCommandHandler(IIdentityProviderService identityProviderService)
    {
        _identityProviderService = identityProviderService;
    }

    public async Task<Result<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var registerUserResult = await _identityProviderService.RegisterUserAsync(
            new UserModel(request.Email, request.Password, request.FirstName, request.LastName),
            cancellationToken);

        if (registerUserResult.IsFailure)
        {
            return Result.Failure<string>(registerUserResult.Error);
        }

        //TODO: Insert new created user to db


        return registerUserResult.Value;
    }
}
