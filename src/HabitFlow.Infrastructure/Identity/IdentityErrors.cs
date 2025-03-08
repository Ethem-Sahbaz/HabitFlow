using HabitFlow.SharedKernel;

namespace HabitFlow.Infrastructure.Identity;
public static class IdentityErrors
{
    public static Error ConfidentialClientAccessTokenFailed = new(
        "IdentityError.ConfidentialClientTokenFailed", "Access token for confidential client could not be obtained.");

    public static Error CreateUserFailed = new(
        "IdentityError.CreateUserFailed", "Creating a user failed.");

    public static Error LocationHeaderNull = new(
        "IdentityErrors.LocationHeaderNull", "Identity Providers header was null.");
}
