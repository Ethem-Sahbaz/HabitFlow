var builder = DistributedApplication.CreateBuilder(args);

// WithDataVolume helps persist the Data between application starts.
var keycloak = builder.AddKeycloak("keycloak", 8080)
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent)
    .WithExternalHttpEndpoints();


var sql = builder.AddSqlServer(name: "sql", port: 1533)
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

var db = sql.AddDatabase("HabitFlowDb");


builder.AddProject<Projects.HabitFlow_Api>("habitflow-api")
    .WithExternalHttpEndpoints()
    .WithReference(db)
    .WaitFor(db)
    .WithReference(keycloak)
    .WaitFor(keycloak);

builder.Build().Run();
