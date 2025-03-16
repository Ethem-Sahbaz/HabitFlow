using HabitFlow.Api.Abstractions;
using System.Reflection;

namespace HabitFlow.Api.Extensions;

public static class EndpointMapping
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {

        var assembly = Assembly.GetExecutingAssembly();

        var endpointTypes = assembly.GetTypes()
            .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

        foreach (var endpointType in endpointTypes)
        {
            var endpoint = (IEndpoint)Activator.CreateInstance(endpointType)!;

            endpoint.MapEndpoint(app);
        }

        return app;
    }
}
