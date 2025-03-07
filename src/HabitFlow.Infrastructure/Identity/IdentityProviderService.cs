using HabitFlow.Application.Abstractions.Identity;
using HabitFlow.SharedKernel;

namespace HabitFlow.Infrastructure.Identity;
internal sealed class IdentityProviderService : IIdentityProviderService
{

    private readonly KeyCloakService _keyCloakService;

    public IdentityProviderService(KeyCloakService keyCloakService)
    {
        _keyCloakService = keyCloakService;
    }

    public async Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default)
    {
        var userRepresentation = new UserRepresentation(
            user.Email,
            user.Email,
            user.FirstName,
            user.LastName,
            true,
            true,
            [new CredentialRepresentation("password", user.Password, false)]);

        await _keyCloakService.RegisterUserAsync(userRepresentation, cancellationToken);

        return Result.Success("Test");
    }
}
