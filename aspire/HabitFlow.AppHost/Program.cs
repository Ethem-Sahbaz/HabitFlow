var builder = DistributedApplication.CreateBuilder(args);

// WithDataVolume helps persist the Data between application starts.
var keycloak = builder.AddKeycloak("keycloak", 8080)
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent)
    .WithExternalHttpEndpoints();

// Research what WithExternalHttpEndpoints does.
builder.AddProject<Projects.HabitFlow_Api>("habitflow-api")
    .WithExternalHttpEndpoints()
    .WithReference(keycloak)
    .WaitFor(keycloak);

builder.Build().Run();
