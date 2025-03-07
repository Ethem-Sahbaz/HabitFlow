using System.Net.Http.Json;

namespace HabitFlow.Infrastructure.Identity;
internal sealed class KeyCloakService
{
    private readonly HttpClient _httpClient;

    public KeyCloakService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task RegisterUserAsync(UserRepresentation user, CancellationToken cancellationToken = default)
    {
        // TODO: Client Secret needs to be set.
        var response = await _httpClient.PostAsJsonAsync("users", user, cancellationToken);

    }
}
