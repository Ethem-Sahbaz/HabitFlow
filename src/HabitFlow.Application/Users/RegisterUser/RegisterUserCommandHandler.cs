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
        // TODO: Pass in RegisterUserModel parameters
        await _identityProviderService.RegisterUserAsync(new RegisterUserModel(), cancellationToken);

        return Guid.NewGuid();
    }
}
