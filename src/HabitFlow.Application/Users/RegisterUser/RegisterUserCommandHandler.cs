using HabitFlow.Application.Abstractions.Identity;
using HabitFlow.Application.Abstractions.Messaging;
using HabitFlow.SharedKernel;

namespace HabitFlow.Application.Users.RegisterUser;
internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IIdentityProviderService _identityProviderService;

    public RegisterUserCommandHandler(IIdentityProviderService identityProviderService)
    {
        _identityProviderService = identityProviderService;
    }

    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        await _identityProviderService.RegisterUserAsync(
            new UserModel(request.Email, request.Password, request.FirstName, request.LastName), cancellationToken);

        return Guid.NewGuid();
    }
}
