using HabitFlow.SharedKernel;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace HabitFlow.Infrastructure.Identity;
internal sealed class KeyCloakService
{
    private readonly HttpClient _httpClient;
    private readonly KeyCloakOptions _options;
    public KeyCloakService(HttpClient httpClient, IOptions<KeyCloakOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<Result<string>> RegisterUserAsync(UserRepresentation user, CancellationToken cancellationToken = default)
    {
        var tokenResut = await GetAuthorizationToken();

        if (tokenResut.IsFailure)
        {
            return Result.Failure<string>(tokenResut.Error);
        }

        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {tokenResut.Value}");

        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("users", user, cancellationToken);

        if (response.IsSuccessStatusCode == false)
        {
            return Result.Failure<string>(IdentityErrors.CreateUserFailed);
        }

        var identityId = response.Headers.Location?.LocalPath.Split("/").Last();

        if (identityId is null)
        {
            return Result.Failure<string>(IdentityErrors.LocationHeaderNull);
        }

        return Result.Success(identityId);
    }

    private async Task<Result<AccessToken>> GetAuthorizationToken()
    {
        // RequestDelegate to set a new Bearer Token for every request the admin confidential client needs to do.
        // Thats why a HttpRequestDelegate is used.

        var authParameters = new KeyValuePair<string, string>[]
        {
            new("client_id",_options.ConfidentialClientId),
            new("client_secret",_options.ConfidentialClientSecret),
            new("scope","openid"),
            new("grant_type","client_credentials")
        };

        using var authRequestContent = new FormUrlEncodedContent(authParameters);

        using var authRequest = new HttpRequestMessage(HttpMethod.Post, new Uri(_options.TokenUrl));
        authRequest.Content = authRequestContent;

        var response = await _httpClient.SendAsync(authRequest);

        var token = await response.Content.ReadFromJsonAsync<AccessToken>();

        if (response.IsSuccessStatusCode == false || token is null)
        {
            return Result.Failure<AccessToken>(IdentityErrors.ConfidentialClientAccessTokenFailed);
        }

        return token;

    }
}
