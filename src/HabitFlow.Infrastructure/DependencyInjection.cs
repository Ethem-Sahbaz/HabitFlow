using HabitFlow.Application.Abstractions.Identity;
using HabitFlow.Infrastructure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace HabitFlow.Infrastructure;
public static class DependencyInjection
{
    public static IHostApplicationBuilder AddAspireInfrastructureOrchestration(this IHostApplicationBuilder builder)
    {
        AddSqlDatabase(builder);

        AddKeycloakAuthentication(builder);

        return builder;
    } 


    private static void AddSqlDatabase(IHostApplicationBuilder builder)
    {
        // Maybe get value from configuration.

        builder.AddSqlServerClient("HabitFlowDb");
    }

    private static void AddKeycloakAuthentication(IHostApplicationBuilder builder)
    {
        builder.Services.AddTransient<IIdentityProviderService, IdentityProviderService>();

        var configuration = builder.Configuration;

        builder.Services.AddAuthorization();

        builder.Services.AddAuthentication()
            .AddKeycloakJwtBearer("keycloak", realm: "habitflow", options =>
            {
                options.RequireHttpsMetadata = false;
                options.Audience = "account";
            });

        builder.Services.Configure<KeyCloakOptions>(configuration.GetSection("KeyCloak"));
        
        builder.Services.AddHttpClient<KeyCloakService>((serviceProvider, client) =>
        {
            var keycloakOptions = serviceProvider.GetRequiredService<IOptions<KeyCloakOptions>>().Value;

            client.BaseAddress = new Uri(keycloakOptions.AdminUrl);
            
        });
    }
}
