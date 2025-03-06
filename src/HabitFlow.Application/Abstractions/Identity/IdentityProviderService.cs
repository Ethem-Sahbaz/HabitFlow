using HabitFlow.SharedKernel;

namespace HabitFlow.Application.Abstractions.Identity;
public interface IIdentityProviderService
{
    Task<Result<string>> RegisterUserAsync(RegisterUserModel user, CancellationToken cancellationToken = default);
}
