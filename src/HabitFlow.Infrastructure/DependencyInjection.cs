using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
        builder.Services.AddAuthorization();

        builder.Services.AddAuthentication()
            .AddKeycloakJwtBearer("keycloak", realm: "habitflow", options =>
            {
                options.RequireHttpsMetadata = false;
                options.Audience = "account";
            });
    }
}
