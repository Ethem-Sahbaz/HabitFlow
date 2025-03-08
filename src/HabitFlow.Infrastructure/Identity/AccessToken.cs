using System.Text.Json.Serialization;

namespace HabitFlow.Infrastructure.Identity;
internal sealed record AccessToken()
{
    [JsonPropertyName("access_token")]
    public required string Value { get; init; }
}
